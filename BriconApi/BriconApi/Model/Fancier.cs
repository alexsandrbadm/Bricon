using System.Xml.Serialization;

namespace BriconApi.Model
{
    public class Fancier
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        public string License { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string CoordX { get; set; }

        public string CoordY { get; set; }

        public string Serial { get; set; }

        public string Distance { get; set; }

        public string DistanceUnit { get; set; }

        public string DistanceString { get; set; }

        public string FlightDesignated { get; set; }

        public string NaamUnicode { get; set; }

        public string GemeenteUnicode { get; set; }
    }
}