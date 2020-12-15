using System.Xml.Serialization;

namespace BriconApi.Model
{
    public class SendPmReadOutData
    {
        [XmlElement(Namespace = "http://tempuri.org/ReadOutDataSet.xsd")]
        public ReadOutDataSet ReadOutDataSet { get; set; }
    }
}