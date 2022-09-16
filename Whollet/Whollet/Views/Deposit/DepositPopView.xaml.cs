using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Whollet.Views.FirstTimeInApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Deposit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepositPopView : ContentView
    {
        DepositPopViewModel viewModel;
        public DepositPopView(DepositPopViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
            KycEmptyPage.DepositPageHeight += KycEmptyPage_DepositPageHeight;
        }

        private void KycEmptyPage_DepositPageHeight(object sender, double e)
        {
            if (e <= 500)
            {
                pcake.WidthRequest = 150;
                pcake.HeightRequest = 150;
                barcodeOptions.Height = 150;
                barcodeOptions.Width = 150;
                mainGrid.Scale = 0.9;
                mainGrid.TranslationY = -30;
            }
            RootPage.HeightRequest = e;
            
        }

        public DepositPopView()
        {
            InitializeComponent();
            viewModel = Startup.Resolve<DepositPopViewModel>();
            BindingContext = viewModel;
            KycEmptyPage.DepositPageHeight += KycEmptyPage_DepositPageHeight;
        }
    }
}