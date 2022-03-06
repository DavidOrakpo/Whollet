using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Whollet.ViewModel.CameraPage
{
    public class CameraPageViewModel : BaseViewModel
    {
        private ImageForm Iform;

        public CameraPageViewModel()
        {

        }

        public CameraPageViewModel(ImageForm iform)
        {
            Iform = iform;
        }

        public Command ProcessImageCommand => new Command(( e) =>
       {
          var temp = e as Xamarin.CommunityToolkit.UI.Views.MediaCapturedEventArgs;
           PreviewSource = temp.Image;
           switch (Iform)
           {
               case ImageForm.NationalID:
                   App.LoggedInUser.NationalID = temp.ImageData;
                   MemoryStream ms = new MemoryStream(App.LoggedInUser.NationalID);
                   break;
               case ImageForm.Passport:
                   App.LoggedInUser.Passport = temp.ImageData;
                   var ms1 = new MemoryStream(App.LoggedInUser.Passport);
                   break;
               case ImageForm.Drivers_License:
                   App.LoggedInUser.Drivers_license = temp.ImageData;
                   var ms2 = new MemoryStream(App.LoggedInUser.Drivers_license);
                   break;
               default:
                   break;
           }
           
           PreviewIsVisible = true;
       });

        private bool previewIsVisible;

        public bool PreviewIsVisible
        {
            get { return previewIsVisible; }
            set { previewIsVisible = value; OnPropertyChanged(); }
        }


        private ImageSource previewsource;
        public ImageSource PreviewSource
        {
            get { return previewsource; }
            set { previewsource = value; OnPropertyChanged(); }
        }

    }
}
