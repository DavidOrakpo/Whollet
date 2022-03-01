using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.CommunityToolkit.Behaviors.Internals;
using Xamarin.Forms;

namespace Whollet.Behaviours
{
    public class PasswordBehaviour : BaseBehavior<VisualElement>
    {
        const string passwordRegex = @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$";

       // public static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(PasswordBehaviour), false);

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(PasswordBehaviour), false);
        Color defaultColor;


        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidProperty, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            var entry = bindable as Entry;
            if (!(entry == null))
            {
                
                defaultColor = entry.TextColor;

                entry.TextChanged += HandleTextChanged;
            }
            
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var EntryText = ((Entry)sender).Text;
            IsValid = (Regex.IsMatch(e.NewTextValue, passwordRegex, RegexOptions.None, TimeSpan.FromMilliseconds(250)));
            var col = ((Entry)sender).TextColor;
            ((Entry)sender).TextColor = IsValid ? defaultColor : Color.Red;
            if (EntryText.Length != 0)
            {
                if (EntryText.Contains(" "))
                {
                    EntryText = ((Entry)sender).Text.Remove(EntryText.Length - 1);
                    ((Entry)sender).Text = EntryText;

                }

            }

        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            var entry = bindable as Entry;
            entry.TextChanged -= HandleTextChanged;

        }
    }
}
