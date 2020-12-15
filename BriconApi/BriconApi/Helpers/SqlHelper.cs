using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace BriconApi.Helpers
{
    public class SqlHelper : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _cache;

        public SqlHelper(Dictionary<Type, Dictionary<string, PropertyInfo>> cache, string connectionString)
        {
            _cache = cache;
            _connectionString = connectionString;
        }

        private SqlConnection Connection
        {
            get
            {
                if (_connection != null && _connection.State == ConnectionState.Open) 
                    return _connection;

                _connection ??= new SqlConnection(_connectionString);
                _connection.Open();

                return _connection;
            }
        }

        public List<TEntity> ListEntity<TEntity>(SqlParamsCommand queryParams)
            where TEntity : new()
        {
            var reader = ExecuteSelect(queryParams);
            if (!reader.HasRows)
                return default;
            var list = new List<TEntity>();
            var properties = typeof(TEntity).GetProperties().ToDictionary(x => x.Name, x => x);
            var readerColumns = ReaderColumns(reader);

            while (reader.Read())
            {
                var entity = new TEntity();
                foreach (var columnName in readerColumns)
                {
                    var property = GetProperty<TEntity>(properties, columnName);

                    var value = reader[columnName];
                    var result = value == null || value is DBNull
                        ? null
                        : ConvertType(value, property.PropertyType);
                    property.SetValue(entity, result, null);

                }
                list.Add(entity);
            }
            return list;
        }

        public TEntity FirstEntity<TEntity>(SqlParamsCommand queryParams)
            where TEntity : new()
        {
            var entity = new TEntity();
            var reader = ExecuteSelect(queryParams);
            if (!reader.HasRows)
                return default;
            var properties = typeof(TEntity).GetProperties().ToDictionary(x => x.Name, x => x);
            var readerColumns = ReaderColumns(reader);

            reader.Read();
            foreach (var columnName in readerColumns)
            {
                var property = GetProperty<TEntity>(properties, columnName);

                var value = reader[columnName];
                var result = value == null || value is DBNull
                    ? null
                    : ConvertType(value, property.PropertyType);
                property.SetValue(entity, result, null);
            }

            return entity;
        }

        private SqlDataReader ExecuteSelect(SqlParamsCommand queryParams)
        {
            using var command = new SqlCommand(queryParams.Query, Connection) { CommandType = CommandType.Text };
            if (queryParams.Params != null && queryParams.Params.Any())
                command.Parameters.AddRange(queryParams.Params);
            return command.ExecuteReader();
        }

        private static List<string> ReaderColumns(IDataRecord reader)
        {
            var columns = new string[reader.FieldCount];
            for (var i = 0; i < columns.Length; i++)
            {
                columns[i] = reader.GetName(i);
            }
            return columns.ToList();
        }

        private PropertyInfo GetProperty<TEntity>(IReadOnlyDictionary<string, PropertyInfo> properties,
            string columnName) where TEntity : new()
        {
            var cache = _cache != null && _cache.ContainsKey(typeof(TEntity))
                ? _cache[typeof(TEntity)]
                : null;
            var property = properties.ContainsKey(columnName)
                ? properties[columnName]
                : cache != null && cache.ContainsKey(columnName)
                    ? cache[columnName]
                    : null;
            if (property == null)
                throw new Exception($"Колонки {columnName} не существует в типе {typeof(TEntity).Name}!");

            return property;
        }

        private static object ConvertType(object value, Type conversionType)
        {
            return conversionType.IsEnum
                ? Enum.ToObject(conversionType, Convert.ChangeType(value, Enum.GetUnderlyingType(conversionType)))
                : Convert.ChangeType(value, Nullable.GetUnderlyingType(conversionType) ?? conversionType);
        }

        public int CallProcedure(SqlParamsCommand prms)
        {
            using var command = new SqlCommand(prms.Query, Connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (prms.WithTransaction || prms.Transaction != null)
            {
                prms.Transaction ??= _transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                _transaction ??= prms.Transaction;

                command.Transaction = prms.Transaction;
            }
            foreach (var prm in prms.Params)
            {
                command.Parameters.Add(prm);
            }
            //command.Parameters.AddRange(prms.Params.ToArray());
            return int.TryParse(command.ExecuteScalar().ToString(), out var newId) ? newId : 0;
        }

        public DataTable SelectQuery(SqlParamsCommand prms)
        {
            var result = new DataTable();
            using var command = new SqlCommand(prms.Query, Connection)
            {
                CommandType = CommandType.Text
            };
            if (_transaction != null && _connection.State == ConnectionState.Open && command.Transaction == null)
                command.Transaction = _transaction;

            if (prms.Params != null && prms.Params.Any())
                command.Parameters.AddRange(prms.Params);
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            return result;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }

    public class SqlParamsCommand
    {
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public string Query { get; set; }
        public SqlParameter[] Params { get; set; }
        public bool WithTransaction { get; set; }
        public SqlTransaction Transaction { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
    }
}