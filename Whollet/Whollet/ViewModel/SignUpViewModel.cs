using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Whollet.Views.Login;
using Whollet.Model;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    internal class SignUpViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private bool passwordValid;
        private bool emailValid;

        public SignUpViewModel()
        {

        }
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public bool PasswordValid
        {
            get => passwordValid;
            set
            {
                passwordValid = value;
                OnPropertyChanged();
            }
        }

        public bool EmailValid
        {
            get
            {
                return emailValid;
            }

            set
            {
                emailValid = value;
                OnPropertyChanged();
            }
        }

        public Command GotoPin => new Command(async () =>
        {
            //await App.GetDatabase.DeleteAllAsync<User>();
            //await App.Current.MainPage.DisplayAlert("Table Deleted", "You reset the table", "Ok");

            if (EmailValid && PasswordValid)
            {
                var _user = new User
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,

                };
                var table = await App.GetDatabase.GetTableAsync<User>();
                if (table.Count() != 0)
                {
                    var temp = table.Where<User>(user => _user.Email == user.Email).FirstOrDefault();
                    if (temp != null)
                    {
                        await App.GetDatabase.UpdateAsync(temp);
                        GoToPageAsync(new CreatePin());
                    }
                    else
                    {
                        await App.GetDatabase.SaveAsync<User>(_user);
                        GoToPageAsync(new CreatePin());
                    }
                }
                else
                {
                    await App.GetDatabase.SaveAsync<User>(_user);
                    GoToPageAsync(new CreatePin());
                }





            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid Email or Password, Try again", "Ok");
            }



        });
        public Command GotoLogin => new Command(async () =>
        {

            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            RemoveCurrentPage();

        });
    }
}
