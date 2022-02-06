using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class DocumentVerificationViewModel : BaseViewModel
    {
        public DocumentVerificationViewModel()
        {

        }

        public Command GoToScan => new Command(() => 
        {
            GoToPageAsync(new FrontDocumentScan());
        });
    }
}
