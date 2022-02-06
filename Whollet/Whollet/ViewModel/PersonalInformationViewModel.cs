using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class PersonalInformationViewModel : BaseViewModel
    {
        public PersonalInformationViewModel()
        {

        }

        public Command GoToNextPage => new Command(() =>
       {
           GoToPageAsync(new DocumentVerificationPage());
       });
    }
}
