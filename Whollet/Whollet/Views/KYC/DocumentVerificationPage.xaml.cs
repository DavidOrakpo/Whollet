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
    public partial class DocumentVerificationPage : ContentPage
    {
        public DocumentVerificationPage(DocumentVerificationViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}