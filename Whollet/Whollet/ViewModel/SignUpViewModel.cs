using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.Login;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    internal class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {

        }
        public Command GotoPin => new Command(() =>
        {

            Application.Current.MainPage.Navigation.PushAsync(new CreatePin());

        });
        public Command GotoLogin => new Command(async () =>
        {

            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            RemoveCurrentPage();

        });
    }
}
