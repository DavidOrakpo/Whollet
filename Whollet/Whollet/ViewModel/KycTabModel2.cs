using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using Whollet.Views.KYC;
using Whollet.Views.FirstTimeInApp;

using Whollet.Enums;
using System.Threading.Tasks;
using Whollet.Views.Wallet;

namespace Whollet.ViewModel
{
    public class KycTabModel2 : BaseViewModel
    {
        private TabViewManager firstviewposition, secondviewposition, thirdviewposition;
        private Dictionary<TabViewManager, ContentView> FirstViewDictionary = new Dictionary<TabViewManager, ContentView>();
        private Dictionary<TabViewManager, ContentView> SecondViewDictionary = new Dictionary<TabViewManager, ContentView>();
        private Dictionary<TabViewManager, ContentView> ThirdViewDictionary = new Dictionary<TabViewManager, ContentView>();
        ContentView firstview, secondview, thirdview;
        private int _index;

        public KycTabModel2(TabViewManager position, int index)
        {

            // Content view dictionaries populated
            //First view dictionary
            FirstViewDictionary.Add(TabViewManager.FirstView, Startup.Resolve<TransactionsView>());
            //Second view dictionary
            SecondViewDictionary.Add(TabViewManager.FirstView, Startup.Resolve<EmptyStateView>());
            SecondViewDictionary.Add(TabViewManager.SecondView, Startup.Resolve<EmptyStatePending>());
            SecondViewDictionary.Add(TabViewManager.ThirdView, Startup.Resolve<EmptyStateFinished>());
            SecondViewDictionary.Add(TabViewManager.FourthView, Startup.Resolve<WalletOverview>());
            //Third view dictionary
            ThirdViewDictionary.Add(TabViewManager.FirstView, Startup.Resolve<PortfolioView>());
            //TabPage assignment
            _index = index;
            ViewSwitcher(_index, position);
            LoadOtherViews();

        }

        private void LoadOtherViews()
        {
            var t = new List<int> { 0, 1, 2 };
            foreach (var indx in t)
            {
                if (indx == _index)
                {

                }
                else
                {
                    ViewSwitcher(indx, TabViewManager.FirstView);
                }
            }
        }

        private void ViewSwitcher(int index, TabViewManager position)
        {
            switch (index)
            {
                case 0:
                    firstviewposition = position;
                    FirstView = FirstViewDictionary[firstviewposition];
                    break;
                case 1:
                    secondviewposition = position;
                    SecondView = SecondViewDictionary[secondviewposition];
                    break;
                case 2:
                    thirdviewposition = position;
                    ThirdView = ThirdViewDictionary[thirdviewposition];
                    break;
                default:
                    break;
            }
        }

        public Command TabChanged => new Command((Object args) =>
        {
            var t = args as Xamarin.CommunityToolkit.UI.Views.TabSelectionChangedEventArgs;
            _index = t.NewPosition;
            switch (_index)
            {
                case 0:
                    ViewSwitcher(_index, firstviewposition);
                    break;
                case 1:
                    ViewSwitcher(_index, secondviewposition);
                    break;
                case 2:
                    ViewSwitcher(_index, thirdviewposition);
                    break;
                default:
                    break;
            }

        });
        public Command ChangeViewCommand => new Command(ChangeView());

        private Action ChangeView()
        {
            return () =>
            {
                //use Index to determine which tab page is currently on screen. 
                switch (_index)
                {   case 0:
                        switch (firstviewposition)
                        {
                            case TabViewManager.FirstView:
                                FirstView = FirstViewDictionary[TabViewManager.SecondView];
                                FirstView.BindingContext = this;
                                firstviewposition = TabViewManager.SecondView;
                                // MessagingCenter.Send<object>(this, "Hi");
                                break;
                            case TabViewManager.SecondView:
                                FirstView = FirstViewDictionary[TabViewManager.SecondView];
                                FirstView.BindingContext = this;
                                firstviewposition = TabViewManager.SecondView;
                                break;
                            case TabViewManager.ThirdView:
                                FirstView = FirstViewDictionary[TabViewManager.SecondView];
                                FirstView.BindingContext = this;
                                firstviewposition = TabViewManager.SecondView;
                                //Currentview = ContentViewDictionary[TabViewManager.FourthView];
                                //Currentview.BindingContext = this;
                                //_position = TabViewManager.FourthView;
                                break;
                            case TabViewManager.FourthView:
                                SecondView = SecondViewDictionary[TabViewManager.FifthView];
                                //  Currentview.BindingContext = this;
                                //  _position = TabViewManager.FifthView;
                                break;
                            case TabViewManager.FifthView:
                                SecondView = SecondViewDictionary[TabViewManager.SixthView];
                                SecondView.BindingContext = this;
                                secondviewposition = TabViewManager.SixthView;
                                break;
                            case TabViewManager.SixthView:
                                SecondView = SecondViewDictionary[TabViewManager.SeventhView];
                                SecondView.BindingContext = this;
                                secondviewposition = TabViewManager.SeventhView;
                                break;
                            case TabViewManager.SeventhView:
                                break;
                            default:
                                break;
                        }
                        // Write code controlling view navigation within first tab
                        break;
                    case 1:
                        switch (secondviewposition)
                        {
                            case TabViewManager.FirstView:
                                SecondView = SecondViewDictionary[TabViewManager.SecondView];
                                SecondView.BindingContext = this;
                                secondviewposition = TabViewManager.SecondView;
                                // MessagingCenter.Send<object>(this, "Hi");
                                break;
                            case TabViewManager.SecondView:
                                SecondView = SecondViewDictionary[TabViewManager.ThirdView];
                                SecondView.BindingContext = this;
                                secondviewposition = TabViewManager.ThirdView;
                                break;
                            case TabViewManager.ThirdView:
                                SecondView.BindingContext = this;
                                Application.Current.MainPage.DisplayAlert("Testing", "It works", "Ok");
                                //Currentview = ContentViewDictionary[TabViewManager.FourthView];
                                //Currentview.BindingContext = this;
                                //_position = TabViewManager.FourthView;
                                break;
                            case TabViewManager.FourthView:
                                SecondView = SecondViewDictionary[TabViewManager.FifthView];
                                //  Currentview.BindingContext = this;
                                //  _position = TabViewManager.FifthView;
                                break;
                            case TabViewManager.FifthView:
                                SecondView = SecondViewDictionary[TabViewManager.SixthView];
                                SecondView.BindingContext = this;
                                secondviewposition = TabViewManager.SixthView;
                                break;
                            case TabViewManager.SixthView:
                                SecondView = SecondViewDictionary[TabViewManager.SeventhView];
                                SecondView.BindingContext = this;
                                secondviewposition = TabViewManager.SeventhView;
                                break;
                            case TabViewManager.SeventhView:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        // Write code controlling view navigation within first tab
                        break;
                    default:
                        break;
                }
                
            };
        }

        public Command MoveBackCommand => new Command(() =>
        {
            switch (secondviewposition)
            {
                case TabViewManager.FirstView:
                    RemoveCurrentPage();
                    break;
                case TabViewManager.SecondView:
                    SecondView = SecondViewDictionary[TabViewManager.FirstView];
                    SecondView.BindingContext = this;
                    secondviewposition = TabViewManager.FirstView;
                    break;
                case TabViewManager.ThirdView:
                    SecondView = SecondViewDictionary[TabViewManager.SecondView];
                    SecondView.BindingContext = this;
                    secondviewposition = TabViewManager.SecondView;
                    break;
                case TabViewManager.FourthView:
                    SecondView = SecondViewDictionary[TabViewManager.ThirdView];
                    SecondView.BindingContext = this;
                    secondviewposition = TabViewManager.ThirdView;
                    break;
                case TabViewManager.FifthView:
                    SecondView = SecondViewDictionary[TabViewManager.FourthView];
                    SecondView.BindingContext = this;
                    secondviewposition = TabViewManager.FourthView;
                    break;
                case TabViewManager.SixthView:
                    SecondView = SecondViewDictionary[TabViewManager.FifthView];
                    SecondView.BindingContext = this;
                    secondviewposition = TabViewManager.FifthView;
                    break;
                case TabViewManager.SeventhView:
                    break;
                default:
                    break;
            }
        });
        public ContentView SecondView
        {
            get
            {
                return secondview;
            }

            set
            {
                secondview = value;
                OnPropertyChanged();
            }
        }
        public ContentView FirstView
        {
            get { return firstview; }
            set { firstview = value; OnPropertyChanged(); }
        }
        public ContentView ThirdView
        {
            get { return thirdview; }
            set { thirdview = value; OnPropertyChanged(); }
        }

    }
}
