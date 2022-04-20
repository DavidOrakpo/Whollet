using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletOverview : ContentView
    {
        Color buttoncolor;
        Label lastElementSelected;
        Grid gridselected;
        public WalletOverview(WalletOverviewViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    if (lastElementSelected is not null)
        //    {
        //        VisualStateManager.GoToState(lastElementSelected, "UnSelected");
        //    }
        //    VisualStateManager.GoToState((Label)sender, "Selected");
        //    lastElementSelected = (Label)sender;
        //}
        //private void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        //{
        //    if (gridselected is not null)
        //    {
        //        VisualStateManager.GoToState(gridselected, "UnSelected");
        //    }
        //    VisualStateManager.GoToState((Grid)sender, "Selected");
        //    gridselected = (Grid)sender;
        //  //  var t = cview.SelectedItem;
        //  //  cview.SelectionChangedCommand.Execute(this.cview.SelectedItem);
        //}



        //private void Button_Pressed(object sender, EventArgs e)
        //{

        //    var b = (Button)sender;
        //    buttoncolor = b.BackgroundColor;
        //    b.BackgroundColor = Color.White;
        //    b.Opacity = 0.1;
        //    b.TextColor = Color.White;
        //}

        //private void Button_Released(object sender, EventArgs e)
        //{
        //    var b = (Button)sender;

        //    b.BackgroundColor = buttoncolor;
        //    b.Opacity = 1;
        //    b.TextColor = Color.White;
        //}
    }
}