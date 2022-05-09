using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupView : ContentPage
    {
        SignUpViewModel viewModel;
        public SignupView(SignUpViewModel vm)
        {
            viewModel = vm;
            BindingContext = viewModel;
            InitializeComponent();
            
        }

        
    }
}