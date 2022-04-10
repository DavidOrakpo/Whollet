using System;
using System.Collections.Generic;
using System.Text;

namespace Whollet.Model.APIModels
{

    public class PriceHistoryData
    {
        public string success { get; set; }
        public string message { get; set; }
        public Data[] data { get; set; }
    }
    public class Price
    {
        public float CryptoPrice { get; set; }
    }
    public class Data
    {
        public int id { get; set; }
        public string token { get; set; }
        public float price { get; set; }
        public int _change { get; set; }
        public string currency { get; set; }
        public DateTime created_at { get; set; }
    }

}
