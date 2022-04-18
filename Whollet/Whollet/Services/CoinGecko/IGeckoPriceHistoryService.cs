using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whollet.Model.APIModels;

namespace Whollet.Services.CoinGecko
{
    public interface IGeckoPriceHistoryService
    {
        Task<CoinGeckoPrice> GetCoinGeckoPriceHistory(string currency, DateTime from, DateTime to, string id = "bitcoin");
        Task<IEnumerable<LatestListings>> GetGeckoLatest(string currency = "usd", int limit = 10);
    }
}