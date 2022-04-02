using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Whollet.Views.Login;
using Whollet.Model;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Whollet.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private bool passwordValid;
        private bool emailValid = false;
        private bool alltrue;

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
               // GotoPin.ChangeCanExecute();
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
                GotoPin.ChangeCanExecute();
            }
        }

        public Command GotoPin => new Command(async () =>
        {
            //await App.GetDatabase.DeleteAllAsync<User>();
            //await App.Current.MainPage.DisplayAlert("Table Deleted", "You reset the table", "Ok");
            //GoToPageAsync(new CreatePin());
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName))
            {
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
                        var temp = table.Where<User>(user => _user.Email == user.Email && String.IsNullOrEmpty(user.Pincode)).FirstOrDefault();
                        if (temp != null)
                        {
                            await App.GetDatabase.UpdateAsync(temp);
                            
                            var createpin = ActivatorUtilities.CreateInstance<CreatePin>(Startup.serviceprovider, _user.Email);
                            
                            GoToPageAsync(createpin);


                        }
                        else
                        {
                            await App.GetDatabase.SaveAsync<User>(_user);
                            var createpin = ActivatorUtilities.CreateInstance<CreatePin>(Startup.serviceprovider, _user.Email);

                            GoToPageAsync(createpin);
                           
                        }
                    }
                    else
                    {
                        await App.GetDatabase.SaveAsync<User>(_user);
                        var createpin = ActivatorUtilities.CreateInstance<CreatePin>(Startup.serviceprovider, _user.Email);

                        GoToPageAsync(createpin);
                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Invalid Email or Password, Try again", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Fill in the required details to continue", "Ok");
            }
            



        });

        public Command GotoLogin => new Command(() =>
        {

            GoToPageAsync(Startup.Resolve<LoginPage>());
            RemoveCurrentPage();

        });
    }
}
