using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;
using Whollet.Views.KYC;
using Xamarin.Essentials;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Whollet.ViewModel
{
    public class FrontDocumentScanViewModel : BaseViewModel
    {
        ImageForm Form;
        public FrontDocumentScanViewModel()
        {

        }

        public FrontDocumentScanViewModel(ImageForm form)
        {
            Form = form;
            MediaSet(Form);
        }

        void MediaSet(ImageForm form)
        {
            switch (form)
            {
                case ImageForm.NationalID:
                    if (App.LoggedInUser.NationalID != null || App.LoggedInUser.NationalID.Length != 0)
                    {
                        var ms = new MemoryStream(App.LoggedInUser.NationalID);
                        ImSource = ImageSource.FromStream(() => ms);
                    }
                    break;
                case ImageForm.Passport:
                    if (App.LoggedInUser.Passport != null || App.LoggedInUser.Passport.Length != 0)
                    {
                        var ms = new MemoryStream(App.LoggedInUser.Passport);
                        ImSource = ImageSource.FromStream(() => ms);
                    }
                    break;
                case ImageForm.Drivers_License:
                    if (App.LoggedInUser.Drivers_license != null || App.LoggedInUser.Drivers_license.Length != 0)
                    {
                        var ms = new MemoryStream(App.LoggedInUser.Drivers_license);
                        ImSource = ImageSource.FromStream(() => ms);
                    }
                    break;
                default:
                    break;
            }
        }
            

        async Task MediaPick(ImageForm form, byte[] arr)
        {
            
            switch (form)
            {
                case ImageForm.NationalID:
                    App.LoggedInUser.NationalID = arr;
                    //memoryStream.Close();
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    //THIS CODE WILL BE UPDATED TO INCLUDE BACK DOCUMENT VIEW AFTER TESTING
                    var vm = ActivatorUtilities.CreateInstance<BackDocumentScan>(Startup.serviceprovider, form);
                    
                    GoToPageAsync(vm);
                    break;
                case ImageForm.Passport:
                    App.LoggedInUser.Passport = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    var vm1 = ActivatorUtilities.CreateInstance<BackDocumentScan>(Startup.serviceprovider, form);
                    
                    GoToPageAsync(vm1);
                    break;
                case ImageForm.Drivers_License:
                    App.LoggedInUser.Drivers_license = arr;
                    await App.GetDatabase.UpdateAsync(App.LoggedInUser);
                    var vm2 = ActivatorUtilities.CreateInstance<BackDocumentScan>(Startup.serviceprovider, form);
                    
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


        public Command GoToNextPage => new Command(async () => 
        {
          var t =  await SnapPictureAsync();
          await  MediaPick(Form,t);
        //  GoToPageAsync(new FinalConfirmationPage());
        });

        private async Task<byte[]> SnapPictureAsync()
        {
            var result = await MediaPicker.CapturePhotoAsync();
            var stream = await result.OpenReadAsync();
            //result.ContentType = "image/jpg";
           // ImSource = ImageSource.FromStream(() => stream);
            
            var arr = StreamToByteArray(stream);
            
            MemoryStream memoryStream = new MemoryStream(arr);

            ImSource = ImageSource.FromStream(() => memoryStream);
            return arr;
        }
    }
}
