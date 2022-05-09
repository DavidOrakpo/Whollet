using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.Login;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class CheckEmailViewModel : BaseViewModel
    {
        public CheckEmailViewModel()
        {

        }

        public Command GoToLogin => new Command(async (x) =>
        {
            GoToPageAsync(Startup.Resolve<LoginPage>());
           await RemovePagesFromStack(3);

        });
    }
}
