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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //public void Button_Clicked(object sender, EventArgs e)
        //{
        //    if (EmailEntry.IsPassword == false)
        //    {
        //        EmailEntry.IsPassword = true;
        //    }
        //    else if (EmailEntry.IsPassword)
        //    {
        //        EmailEntry.IsPassword = false;
        //    }

            
            
        //}

        //private void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    if (PasswordEntry.IsPassword == false)
        //    {
        //        PasswordEntry.IsPassword = true;
        //    }
        //    else if (PasswordEntry.IsPassword)
        //    {
        //        PasswordEntry.IsPassword = false;
        //    }
        //}

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