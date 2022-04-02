using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class TransactionsViewModel : BaseViewModel
    {
        public TransactionsViewModel()
        {

        }

        public Command GoToDeposit => new Command(() => { GoToPageAsync(Startup.Resolve<PersonalInformationPage>()); });
    }
}
