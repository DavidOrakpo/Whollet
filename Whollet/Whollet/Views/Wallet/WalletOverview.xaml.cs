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
        Color buttoncolor;
        public WalletOverview(WalletOverviewViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void Button_Pressed(object sender, EventArgs e)
        {

            var b = (Button)sender;
            buttoncolor = b.BackgroundColor;
            b.BackgroundColor = Color.White;
            b.Opacity = 0.1;
            b.TextColor = Color.Black;
        }

        private void Button_Released(object sender, EventArgs e)
        {
            var b = (Button)sender;
            
            b.BackgroundColor = buttoncolor;
            b.Opacity = 1;
            b.TextColor = Color.White;
        }
    }
}