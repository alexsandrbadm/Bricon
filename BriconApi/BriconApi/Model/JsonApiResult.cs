using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BriconApi.Model
{
    public class JsonApiResult : IActionResult
    {
        private static readonly JsonSerializerSettings SerializerSettings;
        private object _data;
        private object _error;
        private bool _success;
        private int _statusCode;

        static JsonApiResult()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await ExecuteResultAsync(context.HttpContext);
        }

        public async Task ExecuteResultAsync(HttpContext context)
        {
            var json = JsonConvert.SerializeObject(new {success = _success, data = _data, error = _error},
                SerializerSettings);
            var length = Encoding.UTF8.GetByteCount(json);
            context.Response.StatusCode = _statusCode;
            context.Response.ContentType = "application/json";
            context.Response.ContentLength = length;
            await context.Response.WriteAsync(json);
        }

        public static JsonApiResult Success(object data)
            => new JsonApiResult
            {
                _data = data,
                _success = true,
                _statusCode = StatusCodes.Status200OK
            };

        public static JsonApiResult Error(object error, int? statusCode = null)
            => new JsonApiResult
            {
                _error = error,
                _success = false,
                _statusCode = statusCode ?? StatusCodes.Status400BadRequest
            };
    }
}