using System;
using System.Collections.Generic;
using System.Text;

namespace Whollet.Model.APIModels
{
    


    public class CoinGeckoPrice
    {
        public float[][] prices { get; set; }
        public float[][] market_caps { get; set; }
        public float[][] total_volumes { get; set; }
    }

}
