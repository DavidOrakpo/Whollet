using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model;
using Xamarin.Forms;
using Whollet.Views.Login;

namespace Whollet.ViewModel
{
    class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {

        }
        public Command GotoForgetPassword => new Command(() =>
        {

            Application.Current.MainPage.Navigation.PushAsync(new ForgotPassword());

        });

        public Command GotoVerify => new Command(() =>
        {

            Application.Current.MainPage.Navigation.PushAsync(new VerificationPage());

        });
        public Command GotoSignup => new Command(async () =>
        {

            await Application.Current.MainPage.Navigation.PushAsync(new SignupView());
            RemoveCurrentPage();

        });
    }
}
