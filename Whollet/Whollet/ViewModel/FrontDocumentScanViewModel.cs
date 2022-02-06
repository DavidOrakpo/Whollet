using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;
using Whollet.Views.KYC;

namespace Whollet.ViewModel
{
    public class FrontDocumentScanViewModel : BaseViewModel
    {
        public FrontDocumentScanViewModel()
        {

        }
        public Command GoToNextPage => new Command(() => 
        {
            GoToPageAsync(new BackDocumentScan());
        });
    }
}
