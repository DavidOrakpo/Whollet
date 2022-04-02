using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class PortfolioViewModel : BaseViewModel
    {
        public PortfolioViewModel()
        {

        }

        public Command DepositCommand => new Command(() => 
        {
            GoToPageAsync(Startup.Resolve<PersonalInformationPage>());
        });
    }
}
