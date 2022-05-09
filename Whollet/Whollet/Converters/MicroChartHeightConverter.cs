using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Whollet.Converters
{
    public class MicroChartHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var PageHeight = (double)value;
            if (PageHeight >= 300)
            {
                var chartHeight = PageHeight / 2;
                return chartHeight;
            }
            else
            {
                var chartHeight = PageHeight / 2.2;
                return chartHeight;
            }
            
            
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
