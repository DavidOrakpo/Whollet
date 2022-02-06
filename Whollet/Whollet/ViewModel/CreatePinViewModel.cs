using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Whollet.Views.Login;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class CreatePinViewModel : BaseViewModel
    {
        private string entryText;

        public CreatePinViewModel()
        {
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
