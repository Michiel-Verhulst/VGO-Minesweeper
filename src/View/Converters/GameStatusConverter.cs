using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    class GameStatusConverter : IValueConverter
    {

        public object Won { get; set; }
        public object Lost { get; set; }
        public object InProgress { get; set; }

        // Returns the current state of the game
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gameStatus = (GameStatus)value;
            switch (gameStatus)
            {
                case GameStatus.Won:
                    return Won;

                case GameStatus.Lost:
                    return Lost;

                default:
                    return InProgress;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
