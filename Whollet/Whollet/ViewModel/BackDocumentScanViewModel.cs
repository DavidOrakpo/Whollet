using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace Whollet.ViewModel
{
    public class BackDocumentScanViewModel : BaseViewModel
    {
        ImageForm Form;
        public BackDocumentScanViewModel()
        {

        }

        public BackDocumentScanViewModel(ImageForm form)
        {
            Form = form;
        }

        public Command GoToNextPage => new Command(() =>
        {
            MediaPick(Form);
           // GoToPageAsync(new FinalConfirmationPage());
        });

        async void MediaPick(ImageForm form)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            var stream = await result.OpenReadAsync();
            result.ContentType = "image/jpg";
            //ImSource = ImageSource.FromStream(() => stream);

            var arr = StreamToByteArray(stream);
            MemoryStream memoryStream = new MemoryStream(arr);
            ImSource = ImageSource.FromStream(() => memoryStream);
            switch (form)
            {
                case ImageForm.NationalID:
                    App.LoggedInUser.NationalIDBackScan = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    //THIS CODE WILL BE UPDATED TO INCLUDE BACK DOCUMENT VIEW AFTER TESTING
                    var vm = new FinalConfirmationPageViewModel(form);
                    var nextpage = new FinalConfirmationPage()
                    {
                        BindingContext = vm
                    };
                    GoToPageAsync(nextpage);
                    break;
                case ImageForm.Passport:
                    App.LoggedInUser.PassportBackScan = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    var vm1 = new FinalConfirmationPageViewModel(form);
                    var nextpage1 = new FinalConfirmationPage()
                    {
                        BindingContext = vm1
                    };
                    GoToPageAsync(nextpage1);
                    break;
                case ImageForm.Drivers_License:
                    App.LoggedInUser.Drivers_licenseBackScan = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    var vm2 = new FinalConfirmationPageViewModel(form);
                    var nextpage2 = new FinalConfirmationPage()
                    {
                        BindingContext = vm2
                    };
                    GoToPageAsync(nextpage2);
                    break;
                default:
                    break;
            }



        }

        private ImageSource imsSource;

        public ImageSource ImSource
        {
            get { return imsSource; }
            set { imsSource = value; OnPropertyChanged(); }
        }
    }
}
