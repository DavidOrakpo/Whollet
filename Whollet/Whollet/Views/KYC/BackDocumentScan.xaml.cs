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
    public partial class BackDocumentScan : ContentPage
    {
        public BackDocumentScan(BackDocumentScanViewModel vm, ImageForm imageForm)
        {
            vm = ActivatorUtilities.CreateInstance<BackDocumentScanViewModel>(Startup.serviceprovider, imageForm);
            InitializeComponent();
            BindingContext = vm;
        }
    }
}