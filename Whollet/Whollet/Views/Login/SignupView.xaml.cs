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
    public partial class SignupView : ContentPage
    {
        public SignupView()
        {
            InitializeComponent();
        }

        //private void PasswordEntry_Focused(object sender, FocusEventArgs e)
        //{
        //    PasswordLabel.IsVisible = true;
        //}

        //private void PasswordEntry_Unfocused(object sender, FocusEventArgs e)
        //{
        //    PasswordLabel.IsVisible = false;
        //}

        //private void EmailEntry_Focused(object sender, FocusEventArgs e)
        //{
        //    EmailLabel.IsVisible = true;
        //}

        //private void EmailEntry_Unfocused(object sender, FocusEventArgs e)
        //{
        //    EmailLabel.IsVisible = false;
        //}
    }
}