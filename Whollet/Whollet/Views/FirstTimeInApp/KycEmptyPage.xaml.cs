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
        private KycTabModel2 _model;
        public KycEmptyPage(TabViewManager view, int index)
        {
            _model = ActivatorUtilities.CreateInstance<KycTabModel2>(Startup.serviceprovider, view, index);
            InitializeComponent();
            BindingContext = _model;
            KycTabView.SelectedIndex = index;
            
           // Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 1]);
        }

        

        //protected override bool OnBackButtonPressed()
        //{
        //    if (_model.ChangeViewCommand.CanExecute(null))  // You can add parameters if any
        //    {
        //        _model.ChangeViewCommand.Execute(null); // You can add parameters if any
        //        return false;

        //    }
        //    //MessagingCenter.Subscribe<KycEmptyPage>(this, "Hi", (sender) =>
        //    //{
        //    //    // Do something whenever the "Hi" message is received
        //    //});
        //    return base.OnBackButtonPressed();
        //}

    }
}