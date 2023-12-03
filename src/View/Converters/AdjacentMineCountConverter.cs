using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    public class AdjacentMineCountConverter : IValueConverter
    {

        // Returns the number of adjacent mines
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = (int)value;

            if (count == 0)
            {
                return String.Empty;
            }
            return count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
