using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Linq;
using Xamarin.Essentials;
using Whollet.Views.Login;
using Xamarin.Forms;
using Whollet.Model;

namespace Whollet.ViewModel
{
    public class CreatePinViewModel : BaseViewModel
    {
        private string entryText, _email;
        private User _user;

        public CreatePinViewModel()
        {
            entryText = "";
        }

        public CreatePinViewModel(string email)
        {
            _email = email;
            entryText = "";
           
        }

        public string EntryText { get => entryText; 
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
                var temp = _user.FirstName.ToList().GetRange((_user.FirstName.Length - 3),2);
                try
                {
                    
                    await SecureStorage.SetAsync("oath_token",EntryText);
                }
                catch (Exception ex)
                {

                    throw;
                }
                await Application.Current.MainPage.Navigation.PushAsync(new ConfirmPin());
            }

        });

        public Command BackButtonPressed => new Command((x) =>
        {
            if (EntryText.Length > 0 )
            {
               var temp =  EntryText.Remove(EntryText.Length - 1);
                EntryText = temp;
            }
            
        
        });
    }
}
