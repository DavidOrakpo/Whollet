using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Services.CoinMarketCap;

namespace Whollet.ViewModel
{
    public class WalletOverviewViewModel : BaseViewModel
    {
        private readonly ICryptoService _cryptoservice;

        public WalletOverviewViewModel(ICryptoService cryptoService)
        {
            _cryptoservice = cryptoService;
        }
    }
}
