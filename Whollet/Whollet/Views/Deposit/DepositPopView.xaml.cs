using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
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
        }
        public DepositPopView()
        {
            InitializeComponent();
        }
    }
}