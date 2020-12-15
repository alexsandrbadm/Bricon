using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using BriconApi.Model;
using BriconApi.Repositories;

namespace BriconApi.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("text/xml")]
    public class ApiController : ControllerBase
    {
        private readonly SqlRepository _sqlRepository;

        public ApiController(SqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        [HttpPost("upload-file")]
        [Consumes("text/xml")]
        public string UploadFile()
        {
            var requestContent = GetRequestContentAsString();
            var xml = requestContent
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&#xD;", "");
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var soapBody = xmlDoc.GetElementsByTagName("s:Body")[0];
            var deserializer = new XmlSerializer(typeof(SendPmReadOut));
            var report = (SendPmReadOut)deserializer.Deserialize(new MemoryStream(Encoding.Default.GetBytes(soapBody.InnerXml)));
            _sqlRepository.AddReport(report);
            var fileData = LastFileData();
            return "ok";
        }

        [HttpGet("last-file-data")]
        public JsonApiResult LastFileData()
        {
            var report = _sqlRepository.LastReport();
            return JsonApiResult.Success(report);
        }
        

        private string GetRequestContentAsString()
        {
            using var receiveStream = Request.Body;
            using var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                return readStream.ReadToEndAsync().GetAwaiter().GetResult();
        }
    }
}
