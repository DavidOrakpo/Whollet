using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Whollet.Model.APIModels;

namespace Whollet.Services.Roqqu
{
    public class RoqquPriceService : IRoqquPriceService
    {
        private readonly HttpClient _httpClient;

        public RoqquPriceService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<IEnumerable<Price>> GetPriceHistory(string symbol)
        {
            var response = await _httpClient.GetAsync($"/v1/history?symbol={symbol}");
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<PriceHistoryData>(responseStream);
            var temp = responseObject?.data.Select(p => new Price
            {
                CryptoPrice = p.price
            });
            return temp;
        }
    }
}
