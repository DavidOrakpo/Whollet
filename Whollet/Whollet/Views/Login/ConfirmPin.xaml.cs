using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmPin : ContentPage
    {
        public ConfirmPin(ConfirmPinViewModel vm, string email)
        {
            vm = ActivatorUtilities.CreateInstance<ConfirmPinViewModel>(Startup.serviceprovider, email);
            BindingContext = vm;
            InitializeComponent();
        }
    }
}