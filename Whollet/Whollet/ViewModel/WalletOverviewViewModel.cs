using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Whollet.Model.APIModels;
using Whollet.Services.CoinMarketCap;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class WalletOverviewViewModel : BaseViewModel
    {
        private readonly ICryptoService _cryptoservice;

        public WalletOverviewViewModel(ICryptoService cryptoService)
        {
            _cryptoservice = cryptoService;
            PopulateListCommand.Execute(this);
        }
        public async Task PopulateList()
        {
            var temp = await _cryptoservice.GetLatest();
            LatestListings = new ObservableCollection<LatestListing>(temp);
        }

        public Command PopulateListCommand => new Command(async () =>
        {
            await PopulateList();
        });
        private ObservableCollection<LatestListing> _LatestListing;

        public ObservableCollection<LatestListing> LatestListings
        {
            get { return _LatestListing; }
            set { _LatestListing = value; OnPropertyChanged(); }
        }

    }
}
