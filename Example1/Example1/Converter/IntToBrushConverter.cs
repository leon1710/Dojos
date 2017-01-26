using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Example1.Converter
{
    public class IntToBrushConverter : IValueConverter
    {
        SolidColorBrush green = new SolidColorBrush(Colors.Green);
        //SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush red = new SolidColorBrush(Colors.Red);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool temp = (bool)value;

            if(temp == true)
            {
                return green;
            }else
            {
                return red;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
