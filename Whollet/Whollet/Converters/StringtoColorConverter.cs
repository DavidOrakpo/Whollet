using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Whollet.Converters
{
    public class StringtoColorConverter : IValueConverter
    {
        private Color defaultColor;
        private Color changedColor;

        public Color DefaultColor { get => defaultColor; set => defaultColor = value; }
        public Color ChangedColor { get => changedColor; set => changedColor = value; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputboolean = (bool)value;
            return inputboolean ? ChangedColor : DefaultColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
