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
    public partial class SignUp : ContentView
    {
        string temp = "";
        public SignUp()
        {
            InitializeComponent();
            LabelControl.Text = LabelText;
            LabelControl.IsVisible = LabelIsVisible;
            EntryControl.Placeholder = EntryPlaceholder;
            EntryControl.Text = EntryText;
            EntryControl.IsPassword = EntryIsPassword;
            EntryControl.TextChanged += Entry_TextChanged;
            EntryControl.Focused += Entry_Focused;
            EntryControl.Unfocused += Entry_Unfocused;
            if (!(EntryBehavior == null))
            {
                EntryControl.Behaviors.Add(EntryBehavior);
            }
            
            
            
            EntryControl.SetBinding(Entry.IsPasswordProperty, new Binding("ShowPasswordTrigger.HidePassword"));
            EntryControl.BindingContext = ShowPasswordTrigger;
            
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp = e.NewTextValue;
            EntryText = e.NewTextValue;
            

            if (LabelIsVisible == false)
            {
                LabelIsVisible = true;
            }
            if (EntryText.Length == 0)
            {
                LabelIsVisible = false;
            }

        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            LabelIsVisible = true;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            
            if (temp.Length == 0)
            {
                LabelIsVisible = false;
            }
        }


       // public static readonly BindableProperty LabelPlaceholderProperty = BindableProperty.Create(nameof(LabelPlaceholder),
         //                                                                                   typeof(string),
         //                                                                                   typeof(SignUp),
         //                                                                                   default(string),
              //                                                                              BindingMode.OneWay);

        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText),
                                                                                            typeof(string),
                                                                                            typeof(SignUp), 
                                                                                            default(string),
                                                                                        BindingMode.TwoWay);
        public static readonly BindableProperty LabelIsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(bool),
                                                                                                    typeof(SignUp), default(bool), BindingMode.TwoWay);

        public static readonly BindableProperty EntryPlaceholderProperty = BindableProperty.Create(nameof(EntryPlaceholder),
                                                                                                    typeof(string),
                                                                                                    typeof(SignUp),
                                                                                                    default(string),
                                                                                                    BindingMode.OneWay);

        //public static readonly BindableProperty ButtonClickedProperty = BindableProperty.Create(nameof(ButtonClicked), typeof(EventArgs),
                                                                        //                                typeof(SignUp), default(EventArgs), BindingMode.TwoWay);

        public static readonly BindableProperty EntryIsPasswordProperty = BindableProperty.Create(nameof(EntryIsPassword),
                                                                                                typeof(bool),
                                                                                                typeof(SignUp),
                                                                                                default(bool),
                                                                                                BindingMode.TwoWay);

        public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText),
                                                                                                typeof(string),
                                                                                                typeof(SignUp),
                                                                                                default(string),
                                                                                                BindingMode.TwoWay);

        public static readonly BindableProperty EntryBehaviorProperty = BindableProperty.Create(nameof(EntryBehavior), typeof(Behavior<LoginEntry>),
                                                                                                    typeof(SignUp), default(Behavior<LoginEntry>), BindingMode.TwoWay);

        //  public string LabelPlaceholder 
        //   {
        //     get
        //   {
        //        return (string)GetValue(LabelPlaceholderProperty);
        //  } 
        //     set
        //     {
        //         SetValue(LabelPlaceholderProperty, value);
        //     }
        //   }

        public Behavior<LoginEntry> EntryBehavior 
        { 
            get { return (Behavior<LoginEntry>)GetValue(EntryBehaviorProperty); } 
            set { SetValue(EntryBehaviorProperty, value); } 
        }

        //public EventArgs ButtonClicked
        //{
        //    get { return (EventArgs)GetValue(ButtonClickedProperty);} 
        //    set { SetValue(ButtonClickedProperty, value); } 
        //}

        public string LabelText 
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); } 
        }

        public bool LabelIsVisible
        {
            get { return (bool)GetValue(LabelIsVisibleProperty);}
            set { SetValue(LabelIsVisibleProperty, value);}
        }

        public string EntryPlaceholder
        {
            get { return (string)GetValue(EntryPlaceholderProperty);}
            set { SetValue(EntryPlaceholderProperty, value); }
        }

        public bool EntryIsPassword
        {
            get
            {   
                return (bool)GetValue(EntryIsPasswordProperty);
            }
            set { SetValue(EntryIsPasswordProperty, value);}
        }

        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty);}
            set { SetValue(EntryTextProperty, value);}
        }

        protected override void OnPropertyChanged([CallerMemberName] string temp = null)
        {
            base.OnPropertyChanged(temp);
            if (LabelTextProperty.PropertyName == temp)
            {
                LabelControl.Text = LabelText;
            }
            if (LabelIsVisibleProperty.PropertyName == temp)
            {
                LabelControl.IsVisible = LabelIsVisible;
            }
            if (EntryPlaceholderProperty.PropertyName == temp)
            {
                EntryControl.Placeholder = EntryPlaceholder;
            }
            if (EntryTextProperty.PropertyName == temp)
            {
                EntryControl.Text = EntryText;
            }
            if (EntryIsPasswordProperty.PropertyName == temp)
            {
                EntryControl.IsPassword = EntryIsPassword;
            }
            if (EntryBehaviorProperty.PropertyName == temp)
            {
                EntryControl.Behaviors.Add(EntryBehavior);
            }
        }


    }
}