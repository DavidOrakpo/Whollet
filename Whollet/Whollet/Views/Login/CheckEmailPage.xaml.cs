using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckEmailPage : ContentPage
    {
        public CheckEmailPage()
        {
            InitializeComponent();
        }

        private void ButtonControl_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new LoginPage());
            

        }
    }
}