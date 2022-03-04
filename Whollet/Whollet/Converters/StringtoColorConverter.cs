using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Whollet.Converters
{
    public class StringtoColorConverter : IValueConverter
    {
        public Color DefaultColor;
        public Color ChangedColor;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputstring = value as string;
            return String.IsNullOrEmpty(inputstring) ? DefaultColor : ChangedColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
