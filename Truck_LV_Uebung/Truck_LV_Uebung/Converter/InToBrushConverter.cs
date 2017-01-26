using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Truck_LV_Uebung.Converter
{
    public class InToBrushConverter : IValueConverter
    {
        SolidColorBrush red = new SolidColorBrush(Colors.Red);
        SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush green = new SolidColorBrush(Colors.Green);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Objekt wird übergeben un muss in int umgewandelt werden
            int temp = (int)value;
            if(temp > 20000)
            {
                return red;
            }
            if(temp< 10000)
            {
                return green;
            }
            else
            {
                return yellow;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
