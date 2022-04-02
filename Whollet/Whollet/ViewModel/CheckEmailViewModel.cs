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

        public Command GoToLogin => new Command((x) =>
        {
            GoToPageAsync(Startup.Resolve<LoginPage>());
            RemovePagesFromStack(3);

        });
    }
}
