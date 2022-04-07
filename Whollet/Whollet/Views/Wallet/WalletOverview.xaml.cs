using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletOverview : ContentView
    {
        public WalletOverview(WalletOverviewViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}