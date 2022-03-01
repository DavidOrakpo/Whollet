using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using Whollet.Views.KYC;
using Whollet.Views.FirstTimeInApp;
using Whollet.ViewModel.EmptyStateModels;
using System.Threading.Tasks;

namespace Whollet.ViewModel
{
    public class KycTabModel2 : BaseViewModel
    {
        private Dictionary<string, ContentView> ContentViewDictionary = new Dictionary<string, ContentView>();
        ContentView currentview;

        public KycTabModel2()
        {
            ContentViewDictionary.Add("First_View", new EmptyStateView());
            ContentViewDictionary.Add("Second_View", new EmptyStatePending());
            ContentViewDictionary.Add("Third_View", new EmptyStateFinished());
            Currentview = ContentViewDictionary["First_View"];
        }

        public KycTabModel2(KycEmptyPage tabbedpage)
        {
            ContentViewDictionary.Add("First_View", new EmptyStateView());
            ContentViewDictionary.Add("Second_View", new EmptyStatePending());
            ContentViewDictionary.Add("Third_View", new EmptyStateFinished());
            Currentview = ContentViewDictionary["First_View"];
        }


        public Command ChangeViewCommand => new Command(() =>
        {
            if (Currentview == ContentViewDictionary["First_View"])
            {              
                    Currentview = ContentViewDictionary["Second_View"];
                    Currentview.BindingContext = this;
                    OnPropertyChanged(nameof(Currentview));
            }
            else if (Currentview == ContentViewDictionary["Second_View"])
            {
                    Currentview = ContentViewDictionary["Third_View"];
                    Currentview.BindingContext = this;
            }
            else if (Currentview == ContentViewDictionary["Third_View"])
            {
                Currentview.BindingContext = this;
                Application.Current.MainPage.DisplayAlert("Testing", "It works", "Ok");
            }
        });
        public ContentView Currentview
        {
            get
            {
                return currentview;
            }

            set
            {
                currentview = value;
                OnPropertyChanged();
            }
        }
    }
}
