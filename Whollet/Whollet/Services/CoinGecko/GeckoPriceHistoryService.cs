using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
            var response = await _httpClient.GetAsync($"coins/{id}/market_chart/range?vs_currency={currency}&from={startDateEpoch}&to={endDateEpoch}");
            response.EnsureSuccessStatusCode();
            var responseStream =  await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<CoinGeckoPrice>(responseStream);
            return responseObject;
        }
    }
}
