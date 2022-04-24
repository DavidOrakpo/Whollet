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
        private bool _showDeposit;
        const uint AnimationSpeed = 300;
        private bool PoppedUp = false;

        //public delegate ObservableCollection<LatestListings> DepositSelectedCoin();
        //public DepositSelectedCoin OnDepositTapped { get; set; }

        public static event EventHandler OnDepositTapped;

        public KycEmptyPage(TabViewManager view, int index, bool showDeposit = false)
        {
            _model = ActivatorUtilities.CreateInstance<KycTabModel2>(Startup.serviceprovider, view, index);
            _showDeposit = showDeposit;
            InitializeComponent();
            BindingContext = _model;
            KycTabView.SelectedIndex = index + 1;
            DepositPopViewModel.RemoveDepositEvent += DepositPopViewModel_RemoveDepositEvent;
            
           // Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 1]);
        }

        private void DepositPopViewModel_RemoveDepositEvent(object sender, EventArgs e)
        {
            Tap();
        }

        protected override bool OnBackButtonPressed()
        {

            if (PoppedUp)
            {
                Tap();
                return true;
            }
            else if(_model.MoveBackCommand.CanExecute(_model))  // You can add parameters if any
            {
                _model.MoveBackCommand.Execute(_model);
                return true;// You can add parameters if any
            }
            
            return true;
        }

        private void PageFader_Tapped(object sender, EventArgs e) => Tap();
        

        private async void Tap()
        {
            DepView.TranslateTo(0, Height, AnimationSpeed, Easing.SinInOut);
            await PageFader.FadeTo(0, AnimationSpeed, Easing.SinInOut);
            PageFader.IsVisible = false;
            PoppedUp = false;
        }

        private void Middle_tab_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            if (_showDeposit)
            {
                var rootpageheight = Height;
                var depviewheight = rootpageheight / 4;
                PageFader.IsVisible = true;
                PageFader.FadeTo(1, AnimationSpeed, Easing.SinInOut);
                DepView.TranslateTo(0, depviewheight, AnimationSpeed, Easing.SinInOut);
                OnDepositTapped?.Invoke(this, EventArgs.Empty);

                PoppedUp = true;
            }
            else
            {

            }
            
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