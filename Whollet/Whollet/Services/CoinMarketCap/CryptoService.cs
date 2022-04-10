using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Whollet.Model.APIModels;
using System.Text.Json;
using System.Net.Http;
using System.Linq;

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

        public async Task<IEnumerable<LatestListing>> GetLatest(int limit)
        {
            var response = await _httpclient.GetAsync($"v1/cryptocurrency/listings/latest?limit={limit}");
            response.EnsureSuccessStatusCode();
            var responseStream = await response?.Content.ReadAsStreamAsync();           
            var responseObject = await JsonSerializer.DeserializeAsync<CryptoList>(responseStream);            
            var temp = responseObject?.data?.Select(i => i.id).ToList();
            var IDString = string.Join<int>(",", temp);
            var iconresponse = await _httpclient.GetAsync($"v2/cryptocurrency/info?id={IDString},2&aux=logo");
            iconresponse.EnsureSuccessStatusCode();
            var iconresponseStream = await iconresponse?.Content.ReadAsStringAsync();
            var cryptoLogo = CryptoLogo.FromJson(iconresponseStream);
           // var iconresponseObject = JsonSerializer.Deserialize<CryptoLogo>(iconresponseStream); 
            
            var inner = responseObject?.data?.Select(i => new LatestListing
            {
                id = i.id,
                name = i.name,
                symbol = i.symbol,
                price = i.quote.USD.price,
                volume_24h = i.quote.USD.volume_24h,
                slug = i.slug

            });

            var outer = cryptoLogo?.Data.Select(j => j.Value);

            var joined = inner.Join(outer, i => i.id, o => o.Id, (i, o) => new LatestListing
            {
                id =i.id,
                name=i.name,
                symbol=i.symbol,
                price = i.price,
                volume_24h = i.volume_24h,
                slug = i.slug,
                Logo = o.Logo
            });
            return joined;
        }

        public async Task<IEnumerable<CryptoList>> GetSpecific(List<int> ids)
        {
            var IDString = string.Join<int>(",", ids);
            var response = await _httpclient.GetAsync($"/v2/cryptocurrency/quotes/latest?id={IDString}");
            var responseStream = await response?.Content.ReadAsStreamAsync();
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<IEnumerable<CryptoList>>(responseStream);
        }
    }
}
