using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Whollet.Model.APIModels;

namespace Whollet.Services.CoinGecko
{
    public class GeckoPriceHistoryService : IGeckoPriceHistoryService
    {
        private readonly HttpClient _httpClient;

        public GeckoPriceHistoryService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public long DateTimetoEpochConverter(DateTime dateTime)
        {
            //var dateTime = new DateTime(2021, 02, 21, 22, 0, 0, DateTimeKind.Utc);
            var dateWithOffset = new DateTimeOffset(dateTime).ToUniversalTime();
            long timestamp = dateWithOffset.ToUnixTimeSeconds();
            return timestamp;
        }
        public async Task<CoinGeckoPrice> GetCoinGeckoPriceHistory(string currency, DateTime startdate, DateTime enddate, string id = "bitcoin")
        {

            var startDateEpoch = DateTimetoEpochConverter(startdate);
            var endDateEpoch = DateTimetoEpochConverter(enddate);
            var response = new HttpResponseMessage();
            if (id is null)
            {
                 response = await _httpClient.GetAsync($"coins/bitcoin/market_chart/range?vs_currency={currency}&from={startDateEpoch}&to={endDateEpoch}");
            }
            else
            {
                 response = await _httpClient.GetAsync($"coins/{id}/market_chart/range?vs_currency={currency}&from={startDateEpoch}&to={endDateEpoch}");
            }
            
            response.EnsureSuccessStatusCode();
            var responseStream =  await response.Content.ReadAsStreamAsync();
            var responseObject = await System.Text.Json.JsonSerializer.DeserializeAsync<CoinGeckoPrice>(responseStream);
            return responseObject;
        }

        public async Task<IEnumerable<LatestListings>> GetGeckoLatest(string currency = "usd", int limit = 10)
        {
            var response = await _httpClient.GetAsync($"coins/markets?vs_currency={currency}&per_page={limit}&page=1");
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStringAsync();
           // var responseObject = await System.Text.Json.JsonSerializer.DeserializeAsync<CoinGeckoList>(responseStream);
            var coinGeckoList = CoinGeckoList.FromJson(responseStream);
            var listings = coinGeckoList?.Select(i => new LatestListings
            {
                id = i.Id,
                name = i.Name,
                symbol = i.Symbol,
                price = i.CurrentPrice,

                price_change_24h = i.PriceChange24H,
                Logo = i.Image 
            });
            return listings;
        }
    }
}
