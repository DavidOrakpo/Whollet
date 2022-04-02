using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.KYC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalConfirmationPage : ContentPage
    {
        public FinalConfirmationPage(FinalConfirmationPageViewModel vm, ImageForm image)
        {
            vm = ActivatorUtilities.CreateInstance<FinalConfirmationPageViewModel>(Startup.serviceprovider, image);
            InitializeComponent();
            BindingContext = vm;
        }
    }
}