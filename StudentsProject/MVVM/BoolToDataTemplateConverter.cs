using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StudentsProject.MVVM
{
    /// <summary>
    /// Задает DataTemplate в зависимости от значения bool.
    /// </summary>
    class BoolToDataTemplateConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] paramS;
            // Если источник - bool, в качестве параметра передана строка с двумя ключами DataTemplate
            if (value is bool val && parameter is string str && (paramS = str.Split('|')).Length>1)
            {
                return val
                    ? Application.Current.Resources[paramS[0]] as DataTemplate
                    : Application.Current.Resources[paramS[1]] as DataTemplate;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
