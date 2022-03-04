using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Behaviors.Internals;
using Xamarin.Forms;

namespace Whollet.Behaviours
{
    public class RemoveSpaceBehavior : BaseBehavior<VisualElement>
    {
        protected override void OnAttachedTo(VisualElement bindable)
        {
           
            var entry = bindable as Entry;
            if (!(entry == null))
            {
                entry.TextChanged += Handle_ChangedText;
            }
           // entry.TextChanged += Handle_ChangedText;
        }

        private void Handle_ChangedText(object sender, TextChangedEventArgs e)
        {
            var Entrytext = ((Entry)sender).Text;
            if (Entrytext.Contains(" "))
            {
                Entrytext = ((Entry)sender).Text.Remove(Entrytext.Length - 1);
                ((Entry)sender).Text = Entrytext;

            }
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            var entry = bindable as Entry;
            if (!(entry == null))
            {
                entry.TextChanged -= Handle_ChangedText;
            }
        }
    }
}
