using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class FinalConfirmationPageViewModel : BaseViewModel
    {
        ImageForm Form;
        public FinalConfirmationPageViewModel()
        {

        }

        public FinalConfirmationPageViewModel(ImageForm form)
        {
            Form = form;
            switch (Form)
            {
                case ImageForm.NationalID:
                    MemoryStream memoryStream = new MemoryStream(App.LoggedInUser.NationalID);
                    ImSource = ImageSource.FromStream(() => memoryStream);
                    break;
                case ImageForm.Passport:
                    MemoryStream memoryStream1 = new MemoryStream(App.LoggedInUser.Passport);
                    ImSource = ImageSource.FromStream(() => memoryStream1);
                    break;
                case ImageForm.Drivers_License:
                    MemoryStream memoryStream2 = new MemoryStream(App.LoggedInUser.Drivers_license);
                    ImSource = ImageSource.FromStream(() => memoryStream2);
                    break;
                default:
                    break;
            }
            
        }

        private ImageSource imageSource;

        public ImageSource  ImSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }


        public Command GoToNextPage => new Command(() =>
        {

            //GoToPageAsync(new KycLastConfirmed());  THIS WILL LATER BE IMPLEMENTED AND REACHED
            GoToPageAsync(new DocumentVerificationPage());
        });
    }
}
