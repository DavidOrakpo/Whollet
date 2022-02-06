using MasterClass.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {
        BooltoStringConverter convert = new BooltoStringConverter();
        public VerificationPage()
        {
            InitializeComponent();
            
            //IncomeColorString="#00FF00" ExpenseColorString="#9EA5B1"
            convert.IncomeColorString = "#00FF00";
            convert.ExpenseColorString = "#9EA5B1";
            
        }
        Animation animation = new Animation();
        public async void AnimateEllipse()
        {
            var temp1 = Ellipse1.Fill;
            var temp2 = Ellipse2.Fill;
            var temp3 = Ellipse3.Fill;
            var temp4 = Ellipse4.Fill;

            Ellipse1.Fill = new SolidColorBrush(Color.Red);
            Ellipse2.Fill = new SolidColorBrush(Color.Red);
            Ellipse3.Fill = new SolidColorBrush(Color.Red);
            Ellipse4.Fill = new SolidColorBrush(Color.Red);

            var trans = EllipseGrid.TranslationX;
           await EllipseGrid.TranslateTo(-20, 0, 50);
          await EllipseGrid.TranslateTo(20, 0, 50);
          await  EllipseGrid.TranslateTo(-20, 0, 50);
          await  EllipseGrid.TranslateTo(20, 0, 50);
            EllipseGrid.TranslationX = trans;

            Ellipse1.Fill = temp1;
            Ellipse2.Fill = temp2;
            Ellipse3.Fill = temp3;
            Ellipse4.Fill = temp4;

          //  Ellipse1.SetBinding(BackgroundColorProperty, new Binding("Text.Length", source: PassEntry,converter: convert, converterParameter: "1"));
            
        }

        void EllipseError()
        {
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            AnimateEllipse();
            //EllipseGrid.CancelAnimations();
        }
    }
}