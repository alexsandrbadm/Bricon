using System.Xml.Serialization;
// ReSharper disable InconsistentNaming

namespace BriconApi.Model
{
    public class Pigeon
    {
        [XmlElement("ID")] 
        public byte Id { get; set; }

        [XmlElement("FancierID")] public byte FancierId { get; set; }

        public string ElBand { get; set; }

        public string FedBand { get; set; }

        [XmlElement("ClubID")] public string ClubID { get; set; }

        [XmlElement("FlightID")] public string FlightID { get; set; }

        public string Position1 { get; set; }

        public string Position2 { get; set; }

        public string Position3 { get; set; }

        public string Position4 { get; set; }

        public string Time { get; set; }

        public string Evaluation { get; set; }

        public string TeamNbr { get; set; }
    }
}