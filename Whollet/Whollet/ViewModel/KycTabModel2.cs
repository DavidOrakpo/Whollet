using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using Whollet.Views.KYC;
using Whollet.Views.FirstTimeInApp;
using Whollet.ViewModel.EmptyStateModels;

namespace Whollet.ViewModel
{
    public class KycTabModel2 : BaseViewModel
    {
        private Dictionary<string, ContentView> ContentViewDictionary = new Dictionary<string, ContentView>();
        private KycEmptyPage _tabbedPage;
        EmptyStateViewModel emptyStateViewModel = new EmptyStateViewModel();
        ContentView currentview;

        public KycTabModel2()
        {

            
           // _tabbedPage.BindingContext = this;
            ContentViewDictionary.Add("First_View", new EmptyStateView());
            ContentViewDictionary.Add("Second_View", new EmptyStatePending());
            ContentViewDictionary.Add("Third_View", new EmptyStateFinished());
       
            // var currentview = _tabbedPage.Middle_tab.Content as ContentView;
            emptyStateViewModel.CallNextViewEvent += EmptyStateViewModel_CallNextViewEvent;
            currentview = ContentViewDictionary["First_View"];
          //  _tabbedPage.Middle_tab.Content = currentview;
        }

        public KycTabModel2(KycEmptyPage tabbedpage)
        {

            _tabbedPage = tabbedpage;
            //_tabbedPage.BindingContext = this;
            ContentViewDictionary.Add("First_View", new EmptyStateView());
            ContentViewDictionary.Add("Second_View", new EmptyStatePending());
            ContentViewDictionary.Add("Third_View", new EmptyStateFinished());
            // var currentview = _tabbedPage.Middle_tab.Content as ContentView;

            currentview = ContentViewDictionary["First_View"];
            _tabbedPage.Middle_tab.Content = currentview;
            
            emptyStateViewModel.CallNextViewEvent += EmptyStateViewModel_CallNextViewEvent;
        }

        private void EmptyStateViewModel_CallNextViewEvent(object sender, EventArgs e)
        {
            // ChangeViewCommand.Execute(null);
            Next();
        }

        public Command ChangeViewCommand => new Command(() =>
        {
            EventFired();
            
        });

        private void Next()
        {
            if (currentview == ContentViewDictionary["First_View"])
            {
                currentview = ContentViewDictionary["Second_View"];
            }
            else if (currentview == ContentViewDictionary["Second_View"])
            {
                currentview = ContentViewDictionary["Third_View"];
            }
        }

        private void EventFired()
        {
            
            emptyStateViewModel.CallNextViewEvent += EmptyStateViewModel_CallNextViewEvent;
        }
    }
}
