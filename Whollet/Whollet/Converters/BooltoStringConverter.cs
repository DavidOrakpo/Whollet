using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;

namespace MasterClass.Converters
{
    class BooltoStringConverter : IValueConverter
    {
        public BooltoStringConverter()
        {
            //incomeColor = Color.FromHex(IncomeColorString);
            //expenseColor = Color.FromHex(ExpenseColorString);
        }
        private string incomeColorString;
        private string expenseColorString;

        private Color incomeColor;
        private Color expenseColor;
        //private int minValue;

        public string IncomeColorString { get => incomeColorString; set => incomeColorString = value; }
        public string ExpenseColorString { get => expenseColorString; set => expenseColorString = value; }
        //public int MinValue { get => minValue; set => minValue = value; }

        // TODO: COME BACK TO TEST STRING TO COLOR CONVERTOR
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool tempcolor;

            var convparameter = Int32.Parse(parameter as string);

            if ((Int32)value >= convparameter)
            {
                tempcolor = true;
            } else
                tempcolor = false;
           

            incomeColor = Color.FromHex(IncomeColorString);
            expenseColor = Color.FromHex(ExpenseColorString);
            return tempcolor ? new SolidColorBrush(incomeColor) : new SolidColorBrush(expenseColor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
