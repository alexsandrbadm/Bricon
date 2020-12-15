using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using BriconApi.Attributes;
using BriconApi.Helpers;
using BriconApi.Model;
using BriconApi.Queries;
using Microsoft.Extensions.Configuration;

namespace BriconApi.Repositories
{
    public class SqlRepository
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> EntityCache =
            new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        static SqlRepository()
        {
            var types = typeof(SqlRepository).Assembly.GetTypes().Where(t =>
            {
                var attrs = t.GetCustomAttributes(false);
                return attrs.OfType<SqlEntityAttribute>().Any();
            }).ToArray();

            foreach (var type in types)
            {
                var properties = type.GetProperties();
                var localDict = EntityCache.ContainsKey(type)
                    ? EntityCache[type]
                    : EntityCache[type] = new Dictionary<string, PropertyInfo>();
                foreach (var property in properties)
                {
                    var attrs = property.GetCustomAttributes(typeof(ColumnAttribute), false);
                    if (attrs.Length == 0) continue;
                    var attr = attrs[0] as ColumnAttribute;
                    if (attr == null) continue;
                    localDict[attr.Name] = property;
                }
            }
        }

        public SqlRepository(IConfiguration configuration)
        {
            _sqlHelper = new SqlHelper(EntityCache, configuration.GetConnectionString("PigeonSql"));
        }

        public SendPmReadOut LastReport()
        {
            var fileData = _sqlHelper.FirstEntity<SendPmReadOut>(new SqlParamsCommand
            {
                Query = SqlQueries.LastFileData
            });

            if (fileData is null)
            {
                return new SendPmReadOut
                {
                    Data = new SendPmReadOutData
                    {
                        ReadOutDataSet = new ReadOutDataSet
                        {
                            Fancier = new Fancier(),
                            Pigeons = new Pigeon[0]
                        }
                    }
                };
            }

            var fancier = FancierByFileId(fileData.Id);
            var pigeons = PigeonsByFancierId(fancier.FancierId);
            fileData.Data = new SendPmReadOutData
            {
                ReadOutDataSet = new ReadOutDataSet
                {
                    Fancier = fancier, 
                    Pigeons = pigeons.ToArray()
                }
            };
            return fileData;
        }

        private Fancier FancierByFileId(in int fileId)
        {
            var fancier = _sqlHelper.FirstEntity<Fancier>(new SqlParamsCommand
            {
                Query = SqlQueries.FancierByFileId,
                Params = new []{new SqlParameter { ParameterName = "@fileId", Value = fileId} }
            });
            return fancier;
        }

        private List<Pigeon> PigeonsByFancierId(in int fancierId)
        {
            var pigeons = _sqlHelper.ListEntity<Pigeon>(new SqlParamsCommand
            {
                Query = SqlQueries.PigeonsByFancierId,
                Params = new []{new SqlParameter { ParameterName = "@fancierId", Value = fancierId} }
            });
            return pigeons;
        }

        public void AddReport(SendPmReadOut report)
        {
            SqlTransaction transaction = null;
            try
            {
                AddFileData(report, out var prms, out var fileId);
                transaction = prms.Transaction;
                AddFancier(report.Data.ReadOutDataSet.Fancier, fileId, transaction, out var fancierId);
                foreach (var pigeon in report.Data.ReadOutDataSet.Pigeons)
                    AddPigeon(pigeon, fancierId, transaction);

                transaction.Commit();
            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
        }

        private void AddFileData(SendPmReadOut report, out SqlParamsCommand prms, out int fileId)
        {
            prms = new SqlParamsCommand
            {
                WithTransaction = true,
                Query = SqlQueries.AddFileData,
                Params = new[]
                {
                    new SqlParameter {ParameterName = "@fileName", Value = report.FileName},
                    new SqlParameter {ParameterName = "@fileTime", Value = report.FileTime},
                    new SqlParameter {ParameterName = "@header", Value = report.Header},
                    new SqlParameter {ParameterName = "@readOutTime", Value = report.ReadOutTime}
                }
            };
            fileId = _sqlHelper.CallProcedure(prms);
        }

        private void AddFancier(Fancier fancier, int fileId, SqlTransaction transaction, out int fancierId)
        {
            var prms = new SqlParamsCommand
            {
                Transaction = transaction,
                Query = SqlQueries.AddFancier,
                Params = new[]
                {
                    new SqlParameter {ParameterName = "@id", Value = fancier.Id},
                    new SqlParameter {ParameterName = "@license", Value = fancier.License},
                    new SqlParameter {ParameterName = "@name", Value = fancier.Name},
                    new SqlParameter {ParameterName = "@address   ", Value = fancier.Address},
                    new SqlParameter {ParameterName = "@zipCode", Value = fancier.ZipCode},
                    new SqlParameter {ParameterName = "@city", Value = fancier.City},
                    new SqlParameter {ParameterName = "@coordX", Value = fancier.CoordX},
                    new SqlParameter {ParameterName = "@coordY", Value = fancier.CoordY},
                    new SqlParameter {ParameterName = "@serial", Value = fancier.Serial},
                    new SqlParameter {ParameterName = "@distance", Value = fancier.Distance},
                    new SqlParameter {ParameterName = "@distanceUnit", Value = fancier.DistanceUnit},
                    new SqlParameter {ParameterName = "@distanceString", Value = fancier.DistanceString},
                    new SqlParameter {ParameterName = "@flightDesignated", Value = fancier.FlightDesignated},
                    new SqlParameter {ParameterName = "@naamUnicode", Value = fancier.NaamUnicode},
                    new SqlParameter {ParameterName = "@gemeenteUnicode", Value = fancier.GemeenteUnicode},
                    new SqlParameter {ParameterName = "@fileId", Value = fileId}
                }
            };
            fancierId = _sqlHelper.CallProcedure(prms);
        }

        private void AddPigeon(Pigeon pigeon, in int fancierId, SqlTransaction transaction)
        {
            var prms = new SqlParamsCommand
            {
                Transaction = transaction,
                Query = SqlQueries.AddPigeon,
                Params = new[]
                {
                    new SqlParameter {ParameterName = "@id", Value = pigeon.Id},
                    new SqlParameter {ParameterName = "@fancierID", Value = pigeon.FancierId},
                    new SqlParameter {ParameterName = "@elBand", Value = pigeon.ElBand},
                    new SqlParameter {ParameterName = "@fedBand   ", Value = pigeon.FedBand},
                    new SqlParameter {ParameterName = "@clubID", Value = pigeon.ClubID},
                    new SqlParameter {ParameterName = "@flightID", Value = pigeon.FlightID},
                    new SqlParameter {ParameterName = "@position1", Value = pigeon.Position1},
                    new SqlParameter {ParameterName = "@position2", Value = pigeon.Position2},
                    new SqlParameter {ParameterName = "@position3", Value = pigeon.Position3},
                    new SqlParameter {ParameterName = "@position4", Value = pigeon.Position4},
                    new SqlParameter {ParameterName = "@time", Value = pigeon.Time},
                    new SqlParameter {ParameterName = "@evaluation", Value = pigeon.Evaluation},
                    new SqlParameter {ParameterName = "@teamNbr", Value = pigeon.TeamNbr},
                    new SqlParameter {ParameterName = "@fancier", Value = fancierId}
                }
            };
            _sqlHelper.CallProcedure(prms);
        }
    }
}