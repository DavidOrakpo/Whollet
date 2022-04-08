using System;
using System.Collections.Generic;
using System.Text;

namespace Whollet.Model.APIModels
{
    

    public class AllCrypto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int rank { get; set; }
        public int is_active { get; set; }
        public DateTime first_historical_data { get; set; }
        public DateTime last_historical_data { get; set; }
        public Platform2 platform { get; set; }
    }

    public class Platform2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public string token_address { get; set; }
    }

}
