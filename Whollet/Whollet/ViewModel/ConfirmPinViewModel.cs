using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.Login;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class ConfirmPinViewModel : BaseViewModel
    {
        private string entryText;

        public ConfirmPinViewModel()
        {
            entryText = "";
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
            string pincode;
            if (EntryText.Length == 4)
            {
                try
                {
                  pincode = await SecureStorage.GetAsync("oath_token");
                 
                }
                catch (Exception ex)
                {

                    throw;
                }

                

                if (Int32.Parse(EntryText) == Int32.Parse(pincode))
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Your pin has been registered, Proceed to login", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    RemovePagesFromStack(3);
                }else
                {
                   
                    await App.Current.MainPage.DisplayAlert("Oh no!", "You entered the wrong pin, try again", "Ok");

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
