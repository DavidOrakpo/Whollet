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
    public partial class FrontDocumentScan : ContentPage
    {
        public FrontDocumentScan(FrontDocumentScanViewModel vm, ImageForm imageForm)
        {
            vm = ActivatorUtilities.CreateInstance<FrontDocumentScanViewModel>(Startup.serviceprovider, imageForm);
            InitializeComponent();
            BindingContext = vm;
        }
    }
}