using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Enums;
using Whollet.Views.FirstTimeInApp;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class KycLastConfirmedViewModel : BaseViewModel
    {
        public KycLastConfirmedViewModel()
        {

        }

        public Command GoToWallet => new Command(() =>
        {
            var walletpage = ActivatorUtilities.CreateInstance<KycEmptyPage>(Startup.serviceprovider, TabViewManager.FourthView, 1);
            GoToPageAsync(walletpage);
            RemovePagesFromStack(4);
        });
    }
}
