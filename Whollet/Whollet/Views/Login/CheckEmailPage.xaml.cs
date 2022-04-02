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
    public partial class CheckEmailPage : ContentPage
    {
        public CheckEmailPage(CheckEmailViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void ButtonControl_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(Startup.Resolve<LoginPage>());
            

        }
    }
}