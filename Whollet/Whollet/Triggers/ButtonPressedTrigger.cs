using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Whollet.Triggers
{
    public class ButtonPressedTrigger : TriggerAction<Button>
    {
        public Color ButtonBackgroudColor { get; set; }
        Color DefaultBackgroudColor;
        protected override void Invoke(Button sender)
        {
            var button = sender as Button;
            DefaultBackgroudColor = button.BackgroundColor;
            button.BackgroundColor = ButtonBackgroudColor;
        }
    }
}
