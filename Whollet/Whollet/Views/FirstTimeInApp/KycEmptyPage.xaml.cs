using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using Whollet.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Whollet.Enums;

namespace Whollet.Views.FirstTimeInApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KycEmptyPage : ContentPage
    {
        public KycEmptyPage(TabViewManager view, int index)
        {
            var vm = ActivatorUtilities.CreateInstance<KycTabModel2>(Startup.serviceprovider, view);
            InitializeComponent();
            BindingContext = vm;
            KycTabView.SelectedIndex = index;
            
           // Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 1]);
        }

        //public KycEmptyPage(int index)
        //{
        //    if (index != -1 && index < KycTabView.TabItems.Count)
        //    {
        //        KycTabView.SelectedIndex = index;
        //    }
        //}

       
    }
}