using System.Collections.Generic;

namespace Models
{
    public class CarWorkshop 
    {
        public string CompanyName { get; set; }

        public List<string> CarTrademarks { get;set; }
        public string City { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }
    }
}
