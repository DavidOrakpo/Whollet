using System;
using System.Collections.Generic;
using System.Text;

namespace Whollet.Model.APIModels
{
    

    public class Rootobject
    {
        public Datum[] data { get; set; }
        public Status status { get; set; }
    }

    public class Status
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public string error_message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int cmc_rank { get; set; }
        public int num_market_pairs { get; set; }
        public int circulating_supply { get; set; }
        public int total_supply { get; set; }
        public int max_supply { get; set; }
        public DateTime last_updated { get; set; }
        public DateTime date_added { get; set; }
        public string[] tags { get; set; }
        public object platform { get; set; }
        public object self_reported_circulating_supply { get; set; }
        public object self_reported_market_cap { get; set; }
        //public Quote quote { get; set; }
    }

   

    public class CryptoList
    {
        public float price { get; set; }
        public long volume_24h { get; set; }
        public float volume_change_24h { get; set; }
        public float percent_change_1h { get; set; }
        public float percent_change_24h { get; set; }
        public float percent_change_7d { get; set; }
        public float market_cap { get; set; }
        public int market_cap_dominance { get; set; }
        public float fully_diluted_market_cap { get; set; }
        public DateTime last_updated { get; set; }
    }

    

}
