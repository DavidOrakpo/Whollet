using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RemoveCurrentPage()
        {
            Application.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 2]);
        }

        public void RemovePagesFromStack(int numToRemove)
        {
            for (int i = 1; i <= numToRemove; i++)
            {
                RemoveCurrentPage();
            }
        }

        public async void GoToPageAsync(Page nextpage, bool animated = false)
        {
           await Application.Current.MainPage.Navigation.PushAsync(nextpage, animated);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
