using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class FinalConfirmationPageViewModel : BaseViewModel
    {
        public FinalConfirmationPageViewModel()
        {

        }
        public Command GoToNextPage => new Command(() =>
        {
            GoToPageAsync(new KycLastConfirmed());
        });
    }
}
