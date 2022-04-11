using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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

        private async Task<byte[]> SnapPictureAsync()
        {
            var result = await MediaPicker.CapturePhotoAsync();
            var stream = await result.OpenReadAsync();
            //result.ContentType = "image/jpg";
            //ImSource = ImageSource.FromStream(() => stream);

            var arr = StreamToByteArray(stream);
            MemoryStream memoryStream = new MemoryStream(arr);

            ImSource = ImageSource.FromStream(() => stream);
            return arr;
        }

        public Command GoToNextPage => new Command(async () =>
        {
            var t = await SnapPictureAsync();
            await MediaPick(Form, t);
            // GoToPageAsync(new FinalConfirmationPage());
        });

        async Task MediaPick(ImageForm form, byte[] arr)
        {
            
            switch (form)
            {
                case ImageForm.NationalID:
                    App.LoggedInUser.NationalIDBackScan = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    //THIS CODE WILL BE UPDATED TO INCLUDE BACK DOCUMENT VIEW AFTER TESTING
                    var vm = ActivatorUtilities.CreateInstance<FinalConfirmationPage>(Startup.serviceprovider, form);
                    
                    GoToPageAsync(vm);
                    break;
                case ImageForm.Passport:
                    App.LoggedInUser.PassportBackScan = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    var vm1 = ActivatorUtilities.CreateInstance<FinalConfirmationPage>(Startup.serviceprovider, form);
                    
                    GoToPageAsync(vm1);
                    break;
                case ImageForm.Drivers_License:
                    App.LoggedInUser.Drivers_licenseBackScan = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    var vm2 = ActivatorUtilities.CreateInstance<FinalConfirmationPage>(Startup.serviceprovider, form);
                    
                    GoToPageAsync(vm2);
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
