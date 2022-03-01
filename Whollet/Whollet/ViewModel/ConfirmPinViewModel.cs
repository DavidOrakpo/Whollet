using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Whollet.Model;
using Whollet.Views.Login;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class ConfirmPinViewModel : BaseViewModel
    {
        private string entryText, _email, pcode;
        private User _user;

        public ConfirmPinViewModel()
        {
            entryText = "";
        }

        public ConfirmPinViewModel(string email)
        {
            entryText = "";
            _email = email;
        }

        public string EntryText
        {
            get => entryText;
            set
            {
                entryText = value;
                OnPropertyChanged();
            }
        }

        public Command ButtonPressed => new Command(async (x) =>
        {
            EntryText += x;
            if (EntryText.Length == 4)
            {
                var table = await App.GetDatabase.GetTableAsync<User>();
                _user = table.Where((u) => u.Email == _email).FirstOrDefault();
                try
                {
                  pcode = await SecureStorage.GetAsync(_user.Pincode);
                 
                }
                catch (Exception ex)
                {

                    throw;
                }

                finally
                {
                    if (Int32.Parse(EntryText) == Int32.Parse(pcode))
                    {
                        await App.Current.MainPage.DisplayAlert("Success!", "Your pin has been registered, Proceed to login", "Ok");
                        GoToPageAsync(new LoginPage());
                        RemovePagesFromStack(3);
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert("Oh no!", "You entered the wrong pin, try again", "Ok");

                    }
                }          
            }

        });

        public Command BackButtonPressed => new Command((x) =>
        {
            if (EntryText.Length > 0)
            {
                var temp = EntryText.Remove(EntryText.Length - 1);
                EntryText = temp;
            }


        });
    }
}
