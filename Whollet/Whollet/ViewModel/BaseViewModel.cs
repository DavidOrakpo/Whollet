using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using MvvmHelpers;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Whollet.ViewModel
{
    public abstract class BaseViewModel : MvvmHelpers.BaseViewModel
    {
        

        public async Task RemoveCurrentPage()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
           
        }

        public async Task RemovePagesFromStack(int numToRemove)
        {
            for (int i = 1; i <= numToRemove; i++)
            {
                await Task.Run(() => Application.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 2]));
            }
        }

        public async void GoToPageAsync(Page nextpage, bool animated = false)
        {
           await Application.Current.MainPage.Navigation.PushAsync(nextpage, animated);
        }

        

        public byte[] StreamToByteArray(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }

    
}
