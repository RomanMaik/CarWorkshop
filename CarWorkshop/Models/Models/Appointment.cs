using System;
using System.Collections.Generic;

namespace Models
{
    public class Appointment 
    {

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public List<string> CarTrademarks { get; set; }

        public DateTime AppDate { get; set; }
    }
}
