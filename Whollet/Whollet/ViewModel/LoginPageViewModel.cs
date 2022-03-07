using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model;
using System.Linq;
using Xamarin.Forms;
using Whollet.Views.Login;

namespace Whollet.ViewModel
{
    class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {

        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                OnPropertyChanged();
            }
        }

        private bool emailvalid;

        public bool EmailValid
        {
            get { return emailvalid; }
            set 
            { 
                emailvalid = value;
                OnPropertyChanged();
                GotoVerify.ChangeCanExecute();
            }
        }

        private bool passwordvalid;

        public bool PasswordValid
        {
            get { return passwordvalid; }
            set 
            { 
                passwordvalid = value;
                OnPropertyChanged();
                GotoVerify.ChangeCanExecute();
            }
        }




        public Command GotoVerify => new Command(async () =>
        {
            var table = await App.GetDatabase.GetTableAsync<User>();
            var table2 = await App.GetDatabase.GetTableAsync<Address>();
            var tempUser = table.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
            
            if (tempUser is null)
            {
              await Application.Current.MainPage.DisplayAlert("Uh oh", "Invalid Username or Password, try again", "Ok");
            }
            else
            {
                //TODO: Put a base clause to check for address registration
                tempUser = await App.GetDatabase.GetWithChildAsync<User>(tempUser.ID);
                var verifyvm = new VerificationViewModel(tempUser.Email);
                var nextpage = new VerificationPage
                {
                    BindingContext = verifyvm
                };
                GoToPageAsync(nextpage);
            }
               

        });

        public Command GotoForgetPassword => new Command(() =>
        {
            GoToPageAsync(new ForgotPassword());


        });

        
        public Command GotoSignup => new Command(() =>
        {

            GoToPageAsync(new SignupView());
            RemoveCurrentPage();

        });
    }
}
