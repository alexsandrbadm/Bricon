using System.Xml.Serialization;

namespace BriconApi.Model
{
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class SendPmReadOut
    {
        public int Id { get; set; }
        [XmlElement("header")] public string Header { get; set; }

        [XmlElement("data")] public SendPmReadOutData Data { get; set; }

        [XmlElement("fileName")] public string FileName { get; set; }

        [XmlElement("fileTime")] public string FileTime { get; set; }

        [XmlElement("readOutTime")] public string ReadOutTime { get; set; }
    }
}