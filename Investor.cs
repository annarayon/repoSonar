using System.Xml.Serialization;

namespace REInvestment
{
    public class Investor
    {
        // fields
        [XmlAttribute]
        public string? name { get; set;}
        public string? propertyAddress { get; set; }
        public decimal? askingPrice { get; set; }
        public decimal? repairEstimate { get; set; }
        public decimal? afterRepairValue { get; set; }
        public decimal? projectCostPercentage { get; set; }

        private XmlSerializer oSerializer = new XmlSerializer(typeof(Investor));

        // Constructor

        public Investor() {}

        public Investor( string? name, string? propertyAddress)
        {
            this.name = name;
            this.propertyAddress = propertyAddress;
            this.askingPrice = askingPrice;
            this.repairEstimate = repairEstimate;
            this.afterRepairValue = afterRepairValue;
        }

        public string SerializeXml()
        {
            var oStringWriter = new StringWriter();     //this is an instance of the Stringwriter() class
            oSerializer.Serialize(oStringWriter, this);
            oStringWriter.Close();
            return oStringWriter.ToString();
        }
    }
}