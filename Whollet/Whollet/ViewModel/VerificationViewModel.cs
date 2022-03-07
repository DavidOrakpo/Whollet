using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.FirstTimeInApp;
using Whollet.Views.Login;
using Whollet.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Whollet.Model;
using System.Linq;

namespace Whollet.ViewModel
{
    public class VerificationViewModel : BaseViewModel
    {
        private string entryText, _email, pincode;
        private User _user;

        public VerificationViewModel()
        {
            entryText = "";
        }

        public VerificationViewModel(string email)
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
                    pincode = await SecureStorage.GetAsync(_user.Pincode);

                }
                catch (Exception ex)
                {

                    throw;
                }
                if (Int32.Parse(EntryText) == Int32.Parse(pincode))
                {
                 // await App.Current.MainPage.DisplayAlert("Success!", "You entered the right pin", "Ok");

                   
                 // GoToPageAsync(new KycEmptyPage());
                    var TabPage = new KycEmptyPage();
                    
                    var nextviewmodel = new KycTabModel2(TabPage); 
                    TabPage.BindingContext = nextviewmodel;
                    _user = await App.GetDatabase.GetWithChildAsync<User>(_user.ID);
                    App.LoggedInUser = _user;
                    await Application.Current.MainPage.DisplayAlert("Success", "Logging you in", "Ok");
                    GoToPageAsync(TabPage);
                  RemoveCurrentPage();
                   

                }
                else
                {

                    await App.Current.MainPage.DisplayAlert("Oh no!", "You entered the wrong pin, try again", "Ok");

                }
                //Application.Current.MainPage.Navigation.PushAsync(new ConfirmPin());
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
