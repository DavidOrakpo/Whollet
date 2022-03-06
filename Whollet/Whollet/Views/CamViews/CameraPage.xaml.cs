using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.CamViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
            previewpicture.Rotation = 90;
            //cameraview.Shutter();
        }

        //private void CameraView_MediaCaptured(object sender, Xamarin.CommunityToolkit.UI.Views.MediaCapturedEventArgs e)
        //{
        //    previewpicture.Source = e.Image;
           
        //    previewpicture.IsVisible = true;
        //}

        //private void CameraView_MediaCaptureFailed(object sender, string e)
        //{

        //}

        private void Button_Clicked(object sender, EventArgs e)
        {
            cameraview.Shutter();
            
        }

        private void cameraview_OnAvailable(object sender, bool e)
        {

        }
    }
}