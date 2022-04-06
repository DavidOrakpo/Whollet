using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Whollet.Model.APIModels;

namespace Whollet.Services.CoinMarketCap
{
    public interface ICryptoService
    {

        Task<IEnumerable<CryptoList>> GetLatest();
        Task<IEnumerable<AllCrypto>> AllCryptoCoins();
        Task<IEnumerable<CryptoList>> GetSpecific(List<int> ids);
        //Task Create(CryptoList book);
        //Task Update(CryptoList book);
        //Task Delete(int id);
    }
}
