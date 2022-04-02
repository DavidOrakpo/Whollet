using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Whollet.Model.Helpers;
using Xamarin.Forms;
using Whollet.Views.KYC;
using Whollet.Views.FirstTimeInApp;

namespace Whollet.ViewModel
{
    public class KycTabViewModel : BaseViewModel
    {
        private ObservableCollection<ViewSwitcher> pIndex;
        private int pagenumber, pageviewtemp;
        
        ObservableCollection<ViewSwitcher> vIndex = new ObservableCollection<ViewSwitcher>();
        
        // TWO CONSTRUCTORS: ONE SETS THE INITIAL TAB VIEW WITH 3 CONTENT VIEW PAGES WITHIN
        // THE OTHER SETS DYNAMIC CONTENT VIEWS WITHIN THE TAB VIEW df

        // TODO: Implement a parameter in the constructor to take a KycEmptyPage instance.

        //Test if a list/Dictionary of Content views can be made and looped through to avoid using DataTemplate Selectors
        public KycTabViewModel()
        {   
            //var tabpage = new KycEmptyPage();
            //tabpage.Mid
            PIndex = ResetCollection(1);           
        }

        

        public KycTabViewModel(int pnum = 0, int pageviewtemplates = 0)
        {
            
            pagenumber = pnum;
            pageviewtemp = pageviewtemplates;
            PIndex = ResetCollection(pnum);
        }
        //FUNCTION POPULATES THE LIST THAT CONTAINS THE SINGLE OBJECT OF VIEW SWITCHER CLASS
        //SAID OBJECT HAS THE PAGE INDEX VARIABLE MODIFIED. IT IS THROUGH THIS, WE WILIL SWITCH PAGES
        public ObservableCollection<ViewSwitcher> ResetCollection( int temp = 0)
        {
            if (vIndex.Count == 0)
            {
                vIndex.Add(new ViewSwitcher()
                {
                    PageIndex = temp,
                    PageChange = PageChangeCommand

                }) ;
               
                return vIndex;
            }
            else
            {              
                return vIndex;
            }
        }

        public ObservableCollection<ViewSwitcher> PIndex
        {
            get { return pIndex; }
            set
            {                
                pIndex = value;               
                OnPropertyChanged();
            }
        }

        //THE PAGE CHANGE COMMAND IS RESPONSIBLE FOR CHANGING THE VALUE OF THE PAGE INDEX VARIABLE AS REQUIRED

        public Command PageChangeCommand => new Command(() =>
        {        
            if (pagenumber > 0 && pagenumber >= 4)
            {
                var temp = PIndex[0].PageIndex;
                if (PIndex[0].PageIndex < pageviewtemp + pagenumber)
                {                   
                    PIndex.Clear();
                    PIndex.Add(new ViewSwitcher { PageIndex = temp + 1, PageChange = PageChangeCommand });
                    vIndex = PIndex;
                    OnPropertyChanged(nameof(PIndex));                   
                }
            }

            
            ///////////////////////////////////////////////////////////////////////
            if (PIndex[0].PageIndex == 3)
            {
                GoToPageAsync(Startup.Resolve<PersonalInformationPage>());
                PIndex[0].PageIndex--;
            }
            if (PIndex[0].PageIndex < 3)
            {
                 var temp = PIndex[0].PageIndex;
                PIndex.Clear();
                PIndex.Add( new ViewSwitcher { PageIndex = temp + 1, PageChange = PageChangeCommand });
                vIndex = PIndex;
                OnPropertyChanged(nameof(PIndex));
            }       
        });
    }
}
