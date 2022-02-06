using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class BackDocumentScanViewModel : BaseViewModel
    {
        public BackDocumentScanViewModel()
        {

        }

        public Command GoToNextPage => new Command(() =>
        {
            GoToPageAsync(new FinalConfirmationPage());
        });
    }
}
