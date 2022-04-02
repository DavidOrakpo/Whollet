using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model;
using Xamarin.Forms;
using Whollet.Views.Login;

namespace Whollet.ViewModel
{
    public class OnboardingViewModel : BaseViewModel
    {
        public OnboardingViewModel()
        {
            OnboardLayout = OnboardImages();
            // Application.Current.MainPage.Navigation.PushAsync()
        }
        public ObservableCollection<CryptImages> OnboardLayout { get; set; }
        private ObservableCollection<CryptImages> OnboardImages ()
        {
            ObservableCollection<CryptImages> cryptImages = new ObservableCollection<CryptImages>()
            {
                new CryptImages() { OnboardingImage = "cryptoimage.png", Title = "Welcome to Whollet", Description = "Manage all your crypto assets! It’s simple and easy!" },
                new CryptImages() { OnboardingImage = "cryptoimage2.png", Title = "Nice and Tidy Crypto Portfolio!", Description = "Keep BTC, ETH, XRP, and many other ERC-20 based tokens."},
                new CryptImages() {OnboardingImage = "cryptoimage3.png", Title = "Receive and Send Money to Friends!", Description = "Send crypto to your friends with a personal message attached."},
                new CryptImages() {OnboardingImage = "cryptoimage4.png", Title = " Your Safety is Our Top Priority", Description = "Our top-notch security features will keep you completely safe."}

            };
            return cryptImages;
        }

        public Command WelcomeCommand => new Command(() =>
        {

            GoToPageAsync(Startup.Resolve<WelcomeView>());

        });

        public Command PopCommand => new Command(() =>
        {

            Application.Current.MainPage.Navigation.PopModalAsync(false);

        });
    }
}
