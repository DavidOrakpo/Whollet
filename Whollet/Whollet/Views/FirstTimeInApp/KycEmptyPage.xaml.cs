using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using System.Collections.ObjectModel;
using Whollet.Model;
using Xamarin.Forms.Xaml;
using Whollet.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Whollet.Enums;
using Whollet.Views.Wallet;
using Xamarin.CommunityToolkit.UI.Views;

namespace Whollet.Views.FirstTimeInApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KycEmptyPage : ContentPage
    {
        private KycTabModel2 _model;
        private bool _showDeposit, LeftMenuShown;
        const uint AnimationSpeed = 300;
        private bool PoppedUp = false;

        private double Yposition;
        private double Xposition;
        private bool SwipeOpened;
       


        //public delegate ObservableCollection<LatestListings> DepositSelectedCoin();
        //public DepositSelectedCoin OnDepositTapped { get; set; }

        public static event EventHandler OnDepositTapped;
        public static event EventHandler<double> DepositPageHeight;

        public KycEmptyPage(TabViewManager view, int index, bool showDeposit = false)
        {
            _model = ActivatorUtilities.CreateInstance<KycTabModel2>(Startup.serviceprovider, view, index);
            _showDeposit = showDeposit;
            
            InitializeComponent();
            
            BindingContext = _model;
            KycTabView.SelectedIndex = index + 1;
            KycTabView.SelectionChanged += KycTabView_SelectionChanged;
            DepositPopViewModel.RemoveDepositEvent += DepositPopViewModel_RemoveDepositEvent;
       
            
           // SideMenu.State = SideMenuState.MainViewShown;
            //WalletOverview.OnSideMenuTapped += WalletOverview_OnSideMenuTapped;
            //if (SideMenu?.State == SideMenuState.MainViewShown)
            //{
            //    MainGrid.TranslateTo(Xposition, Yposition, 250, Easing.SinInOut);
            //}

            // Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 1]);
        }

        

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            if (_showDeposit && KycTabView.SelectedIndex == 2)
            {
                Xposition = MainGrid.TranslationX;
                Yposition = MainGrid.TranslationY;
                SideMenu.State = SideMenuState.RightMenuShown;
                MainGrid.TranslateTo(-Width / 2, Yposition, 300, Easing.SinInOut);
                DepView.IsVisible = false;
                

            }
          
                
            
        }

        private void WalletOverview_OnSideMenuTapped(object sender, EventArgs e)
        {
            
             
             
            
            
        }

        private void KycTabView_SelectionChanged(object sender, Xamarin.CommunityToolkit.UI.Views.TabSelectionChangedEventArgs e)
        {
            if (KycTabView.SelectedIndex == 0)
            {
                MainSwpieView.IsEnabled = false;
            }
            else
            {
                MainSwpieView.IsEnabled = true;
            }
        }

        private void MainSwpieView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            Yposition = SwipeContent.TranslationY;
            Xposition = SwipeContent.TranslationX;
            
        }

        private void SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (!e.IsOpen)
                CloseAnimation();
        }

        private void MainSwpieView_SwipeChanging(object sender, SwipeChangingEventArgs e)
        {
            switch (e.SwipeDirection)
            {
                case SwipeDirection.Right:
                    CloseAnimation();
                    break;
                case SwipeDirection.Left:
                    OpenAnimation();
                    break;
                case SwipeDirection.Up:
                    break;
                case SwipeDirection.Down:
                    break;
                default:
                    break;
            }
        }

        private void OpenAnimation()
        {
            SwipeOpened = true;
            pcake.CornerRadius = 25;
            Xamarin.CommunityToolkit.Effects.CornerRadiusEffect.SetCornerRadius(SwipeContent, 25);
            
            SwipeContent.ScaleTo(0.8, AnimationSpeed - 50, Easing.SinInOut);
            SwipeContent.TranslateTo(-Width / 2, Yposition, AnimationSpeed - 50, Easing.SinInOut);
            DepView.IsVisible = false;
            PageFader.BackgroundColor = Color.Transparent;
            PageFader.IsVisible = true;

        }

        private void CloseAnimation()
        {
            SwipeOpened = false;
            SwipeContent.ScaleTo(1, AnimationSpeed - 50, Easing.SinInOut);
            SwipeContent.TranslateTo(Xposition, Yposition, AnimationSpeed - 50, Easing.SinInOut);
            pcake.CornerRadius = 0;
            Xamarin.CommunityToolkit.Effects.CornerRadiusEffect.SetCornerRadius(SwipeContent, 0);
            PageFader.IsVisible = false;
            PageFader.BackgroundColor = (Color)Application.Current.Resources["PageFadeColor"]; 
        }

        private void DepositPopViewModel_RemoveDepositEvent(object sender, EventArgs e) => Tap();
        

        protected override bool OnBackButtonPressed()
        {

            if (PoppedUp)
            {
                Tap();
                return true;
            }
            if (SwipeOpened)
            {
                MainSwpieView.Close();
                CloseAnimation();
                return true;
            }
            else if(_model.MoveBackCommand.CanExecute(_model))  // You can add parameters if any
            {
                _model.MoveBackCommand.Execute(_model);
                return true;// You can add parameters if any
            }
            
            return true;
        }

        private void PageFader_Tapped(object sender, EventArgs e)
        {
            if (!SwipeOpened)
            {
                Tap();
            }
            else
            {
                CloseAnimation();
            }
            
        }

        private async void Tap()
        {
            DepView.TranslateTo(0, Height, AnimationSpeed, Easing.SinInOut);
            await PageFader.FadeTo(0, AnimationSpeed, Easing.SinInOut);
            PageFader.IsVisible = false;
            PoppedUp = false;
            MenuBox.IsEnabled = true;
            MenuBox.IsVisible = true;

            if (KycTabView.SelectedIndex == 0)

            {

                MainSwpieView.IsEnabled = false;

            }

            else

            {

                MainSwpieView.IsEnabled = true;

            }


        }

       

        private void Middle_tab_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            if (_showDeposit && !SwipeOpened)
            {
                var rootpageheight = Height;
                var depviewheight = rootpageheight / 4;

                DepView.IsVisible = true;


                PageFader.IsVisible = true;
                MainSwpieView.IsEnabled = false;
                MenuBox.IsEnabled = false;
                MenuBox.IsVisible = false;
                PageFader.FadeTo(1, AnimationSpeed, Easing.SinInOut);
                DepView.IsVisible = true;
                DepView.TranslateTo(0, depviewheight, AnimationSpeed, Easing.SinInOut);
                OnDepositTapped?.Invoke(this, EventArgs.Empty);
                MenuBox.IsEnabled = false;
                MenuBox.IsVisible = false;
                PoppedUp = true;
            }
            else
            {

            }
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MainSwpieView.Close();
            CloseAnimation();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (KycTabView.SelectedIndex != 0)
            {
                MainSwpieView.Open(OpenSwipeItem.RightItems);
                OpenAnimation();
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
