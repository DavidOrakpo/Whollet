using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using Whollet.Views.KYC;
using Whollet.Views.FirstTimeInApp;
using Whollet.ViewModel.EmptyStateModels;
using Whollet.Enums;
using System.Threading.Tasks;

namespace Whollet.ViewModel
{
    public class KycTabModel2 : BaseViewModel
    {
        private TabViewManager _position;
        private Dictionary<TabViewManager, ContentView> ContentViewDictionary = new Dictionary<TabViewManager, ContentView>();
        ContentView currentview;


        public KycTabModel2(TabViewManager position)
        {
            //if (position is not null)
            //{
            //    // Add views to content view dictionary
            //    Currentview = ContentViewDictionary[position];
            //}
                _position = position;
                ContentViewDictionary.Add(TabViewManager.FirstView, Startup.Resolve<EmptyStateView>());
                ContentViewDictionary.Add(TabViewManager.SecondView, Startup.Resolve<EmptyStatePending>());
                ContentViewDictionary.Add(TabViewManager.ThirdView, Startup.Resolve<EmptyStateFinished>());
                Currentview = ContentViewDictionary[_position];
            
            
            
        }


        public Command ChangeViewCommand => new Command(() =>
        {
            switch (_position)
            {
                case TabViewManager.FirstView:
                    Currentview = ContentViewDictionary[TabViewManager.SecondView];
                    Currentview.BindingContext = this;
                    _position = TabViewManager.SecondView;
                    break;
                case TabViewManager.SecondView:
                    Currentview = ContentViewDictionary[TabViewManager.ThirdView];
                    Currentview.BindingContext = this;
                    _position = TabViewManager.ThirdView;
                    break;
                case TabViewManager.ThirdView:
                    Currentview.BindingContext = this;
                    Application.Current.MainPage.DisplayAlert("Testing", "It works", "Ok");
                    //Currentview = ContentViewDictionary[TabViewManager.FourthView];
                    //Currentview.BindingContext = this;
                    //_position = TabViewManager.FourthView;
                    break;
                case TabViewManager.FourthView:
                    Currentview = ContentViewDictionary[TabViewManager.FifthView];
                    Currentview.BindingContext = this;
                    _position = TabViewManager.FifthView;
                    break;
                case TabViewManager.FifthView:
                    Currentview = ContentViewDictionary[TabViewManager.SixthView];
                    Currentview.BindingContext = this;
                    _position = TabViewManager.SixthView;
                    break;
                case TabViewManager.SixthView:
                    Currentview = ContentViewDictionary[TabViewManager.SeventhView];
                    Currentview.BindingContext = this;
                    _position = TabViewManager.SeventhView;
                    break;
                case TabViewManager.SeventhView:
                    break;
                default:
                    break;
            }

            //if (Currentview == ContentViewDictionary["First_View"])
            //{              
            //        Currentview = ContentViewDictionary["Second_View"];
            //        Currentview.BindingContext = this;
                    
            //}
            //else if (Currentview == ContentViewDictionary["Second_View"])
            //{
            //        Currentview = ContentViewDictionary["Third_View"];
            //        Currentview.BindingContext = this;
            //}
            //else if (Currentview == ContentViewDictionary["Third_View"])
            //{
            //    Currentview.BindingContext = this;
            //    Application.Current.MainPage.DisplayAlert("Testing", "It works", "Ok");
            //}
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
