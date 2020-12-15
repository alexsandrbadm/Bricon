using System.Xml.Serialization;

namespace BriconApi.Model
{
    public class ReadOutDataSet
    {
        public Fancier Fancier { get; set; }

        [XmlElement("Pigeons")] public Pigeon[] Pigeons { get; set; }
    }
}