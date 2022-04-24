using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class DepositPopViewModel : BaseViewModel
    {
        private ObservableCollection<LatestListings> _LatestListing;

        public static event EventHandler RemoveDepositEvent;

        public ObservableCollection<LatestListings> LatestListings
        {
            get { return _LatestListing; }
            set { _LatestListing = value; OnPropertyChanged(); }
        }

        public DepositPopViewModel()
        {
            WalletOverviewViewModel.PopulateCarouselView += WalletOverviewViewModel_PopulateCarouselView;
        }

        public Command RemoveDeposit => new Command(() =>
        {
            RemoveDepositEvent?.Invoke(this, EventArgs.Empty);
        });

        //~DepositPopViewModel()
        //{
        //    WalletOverviewViewModel.PopulateCarouselView -= WalletOverviewViewModel_PopulateCarouselView;
        //}

        

        private void WalletOverviewViewModel_PopulateCarouselView(object sender, ObservableCollection<LatestListings> e)
        {
            LatestListings = e;
        }
    }
}
