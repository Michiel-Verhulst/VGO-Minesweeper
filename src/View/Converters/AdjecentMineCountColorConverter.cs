﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    internal class AdjecentMineCountColorConverter : IValueConverter
    {


        public object Zero { get; set; }
        public object One { get; set; }
        public object Two { get; set; }
        public object Three { get; set; }
        public object Four { get; set; }
        public object Five { get; set; }
        public object Six { get; set; }
        public object Seven { get; set; }
        public object Eight { get; set; }

        // Returns an object that matches a color in the xaml (converter UserControl.Resources)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            switch (count)
            {
                case 0:
                    return Zero;

                case 1:
                    return One;

                case 2:
                    return Two;

                case 3:
                    return Three;

                case 4:
                    return Four;

                case 5:
                    return Five;

                case 6:
                    return Six;

                case 7:
                    return Seven;

                case 8:
                    return Eight;

                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
