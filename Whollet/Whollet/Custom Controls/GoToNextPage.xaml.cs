using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Custom_Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoToNextPage : ContentView
    {
        public GoToNextPage()
        {
            InitializeComponent();
            ButtonControl.BackgroundColor = ButtonBackgroundColor;
            ButtonControl.Text = ButtonText;
            ButtonControl.TextColor = ButtonTextColor;
            ButtonControl.Command = ButtonCommand;
            ButtonControl.FontSize = ButtonFontSize;
            DescriptionLabelControl.Text = DescriptionLabelText;
            DescriptionLabelControl.TextColor = DescriptionLabelTextColor;
            ActionLabelControl.TextColor = ActionLabelTextColor;
            ActionLabelControl.Text = ActionLabelText;
            ActionLabelControl.GestureRecognizers.Add(LabelTap);
        }

        protected override void OnPropertyChanged([CallerMemberName] string temp = null)
        {
            base.OnPropertyChanged(temp);
            if (LabelTapProperty.PropertyName == temp)
            {
                ActionLabelControl.GestureRecognizers.Add(LabelTap);
            }
            if (ButtonBackgroundColorProperty.PropertyName == temp)
            {
                ButtonControl.BackgroundColor = ButtonBackgroundColor;
            }
            if (ButtonCommandProperty.PropertyName == temp)
            {
                ButtonControl.Command = ButtonCommand;
            }
            if (ButtonFontSizeProperty.PropertyName == temp)
            {
                ButtonControl.FontSize = ButtonFontSize;
            }
            if (DescriptionLabelTextProperty.PropertyName == temp)
            {
                DescriptionLabelControl.Text = DescriptionLabelText;
            }
            if (ActionLabelTextProperty.PropertyName == temp)
            {
                ActionLabelControl.Text = ActionLabelText;
            }
            if (ButtonTextColorProperty.PropertyName == temp)
            {
                ButtonControl.TextColor = ButtonTextColor;
            }
            if (ButtonTextProperty.PropertyName == temp)
            {
                ButtonControl.Text = ButtonText;
            }
            if (ActionLabelTextColorProperty.PropertyName == temp)
            {
                ActionLabelControl.TextColor = ActionLabelTextColor;
            }
            if (DescriptionLabelTextColorProperty.PropertyName == temp)
            {
                DescriptionLabelControl.TextColor = DescriptionLabelTextColor;
            }
        }

        public Color DescriptionLabelTextColor 
        { 
            get { return (Color)GetValue(DescriptionLabelTextColorProperty); }
            set { SetValue(DescriptionLabelTextColorProperty, value); }
        }

        public Color ActionLabelTextColor 
        {
            get { return (Color)GetValue(ActionLabelTextColorProperty); }
            set { SetValue(ActionLabelTextColorProperty, value); }
        }

        public Color ButtonBackgroundColor
        {
            get { return (Color)GetValue(ButtonBackgroundColorProperty); } 
            set { SetValue(ButtonBackgroundColorProperty, value); } 
        }
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty);}
            set { SetValue(ButtonTextProperty, value); } 
        }

        public Command ButtonCommand
        {
            get { return (Command)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public int ButtonFontSize {
            get { return (int)GetValue(ButtonFontSizeProperty);}
            set { SetValue(ButtonFontSizeProperty, value); } 
        }

        public string DescriptionLabelText 
        {
            get { return (string)GetValue(DescriptionLabelTextProperty);}
            set { SetValue(DescriptionLabelTextProperty, value); } 
        }
        public string ActionLabelText
        { 
            get { return(string)GetValue(ActionLabelTextProperty);}
            set { SetValue(ActionLabelTextProperty, value); }
        }

        public TapGestureRecognizer LabelTap 
        {
            get { return (TapGestureRecognizer)GetValue(LabelTapProperty);}
            set { SetValue(LabelTapProperty, value);}
        }

        public Color ButtonTextColor 
        {
            get { return (Color)GetValue(ButtonTextColorProperty);}
            set { SetValue(ButtonTextColorProperty, value); }
        }


        //BINDABLE PROPERTIES
        public static readonly BindableProperty ActionLabelTextColorProperty = BindableProperty.Create(nameof(ActionLabelTextColor),
                                                                                            typeof(Color), typeof(GoToNextPage), default(Color),
                                                                                          BindingMode.TwoWay);

        public static readonly BindableProperty DescriptionLabelTextColorProperty = BindableProperty.Create(nameof(DescriptionLabelTextColor),
                                                                                            typeof(Color), typeof(GoToNextPage), default(Color),
                                                                                          BindingMode.TwoWay);

        public static readonly BindableProperty ButtonTextColorProperty = BindableProperty.Create(nameof(ButtonTextColor),
                                                                                            typeof(Color), typeof(GoToNextPage), default(Color),
                                                                                          BindingMode.TwoWay);

        public static readonly BindableProperty LabelTapProperty = BindableProperty.Create(nameof(LabelTap), typeof(TapGestureRecognizer), typeof(GoToNextPage),
                                                                                                    default(TapGestureRecognizer), BindingMode.TwoWay);

        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(nameof(ButtonBackgroundColor), 
                                                                                            typeof(Color), typeof(GoToNextPage), default(Color),
                                                                                          BindingMode.TwoWay);
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(GoToNextPage), default(string),
                                                                                                        BindingMode.TwoWay);

        public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(Command),
                                                                                                        typeof(SignUp), default(Command), BindingMode.TwoWay);

        public static readonly BindableProperty ButtonFontSizeProperty = BindableProperty.Create(nameof(ButtonFontSize), typeof(int), typeof(GoToNextPage), default(int), BindingMode.TwoWay);

        public static readonly BindableProperty DescriptionLabelTextProperty = BindableProperty.Create(nameof(DescriptionLabelText), typeof(string),
                                                                                                                            typeof(GoToNextPage), default(string), BindingMode.OneWay);

        public static readonly BindableProperty ActionLabelTextProperty = BindableProperty.Create(nameof(ActionLabelText), typeof(string), typeof(GoToNextPage), default(string), BindingMode.TwoWay);

    }
}