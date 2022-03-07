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
                    var memoryStreambackID = new MemoryStream(App.LoggedInUser.NationalIDBackScan);
                    ImSource = ImageSource.FromStream(() => memoryStream);
                    BackImSource = ImageSource.FromStream(() => memoryStreambackID);
                    break;
                case ImageForm.Passport:
                    MemoryStream memoryStream1 = new MemoryStream(App.LoggedInUser.Passport);
                    var memoryStreambackPassport = new MemoryStream(App.LoggedInUser.PassportBackScan);
                    ImSource = ImageSource.FromStream(() => memoryStream1);
                    BackImSource = ImageSource.FromStream(() => memoryStreambackPassport);
                    break;
                case ImageForm.Drivers_License:
                    MemoryStream memoryStream2 = new MemoryStream(App.LoggedInUser.Drivers_license);
                    var memoryStreambackDrivers = new MemoryStream(App.LoggedInUser.Drivers_licenseBackScan);
                    ImSource = ImageSource.FromStream(() => memoryStream2);
                    BackImSource = ImageSource.FromStream(() => memoryStreambackDrivers);
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

        private ImageSource backImSource;

        public ImageSource BackImSource
        {
            get { return backImSource; }
            set { backImSource = value; OnPropertyChanged(); }
        }



        public Command GoToNextPage => new Command(() =>
        {

            //GoToPageAsync(new KycLastConfirmed());  THIS WILL LATER BE IMPLEMENTED AND REACHED
            GoToPageAsync(new DocumentVerificationPage());
        });
    }
}
