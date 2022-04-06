using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Whollet.Model.APIModels;
using System.Text.Json;
using System.Net.Http;

namespace Whollet.Services.CoinMarketCap
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpclient;

        public CryptoService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public async Task<IEnumerable<AllCrypto>> AllCryptoCoins()
        {
            var response = await _httpclient.GetAsync("/v1/cryptocurrency/map");
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<IEnumerable<AllCrypto>>(responseStream);
            return responseObject;
        }

        public async Task<IEnumerable<CryptoList>> GetLatest()
        {
            var response = await _httpclient.GetAsync("v1/cryptocurrency/listings/latest");
            response.EnsureSuccessStatusCode();
            var responseStream = await response?.Content.ReadAsStreamAsync();
            return JsonSerializer.Deserialize<IEnumerable<CryptoList>>(responseStream); 
        }

        public async Task<IEnumerable<CryptoList>> GetSpecific(List<int> ids)
        {
            var IDString = string.Join<int>(",", ids);
            var response = await _httpclient.GetAsync($"/v2/cryptocurrency/quotes/latest?id={IDString}");
            var responseStream = await response?.Content.ReadAsStreamAsync();
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<IEnumerable<CryptoList>>(responseStream);
        }
    }
}
