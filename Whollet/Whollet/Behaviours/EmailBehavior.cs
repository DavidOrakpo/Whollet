using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Whollet.Custom_Controls;
using Xamarin.CommunityToolkit.Behaviors.Internals;
using Xamarin.Forms;

namespace Whollet.Behaviours
{
    public class EmailBehavior : BaseBehavior<VisualElement>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;
        Color defaultColor;


        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            var entry = bindable as Entry;
            defaultColor = entry.TextColor;
            
            entry.TextChanged += HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var EntryText = ((Entry)sender).Text;
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            var col = ((Entry)sender).TextColor;
            ((Entry)sender).TextColor = IsValid ? defaultColor : Color.Red;
            if (EntryText.Length != 0 )
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
