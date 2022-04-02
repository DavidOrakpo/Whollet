using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.FirstTimeInApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PortfolioView : ContentView
    {
        public PortfolioView(PortfolioViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        public PortfolioView()
        {
            InitializeComponent();
        }
    }
}