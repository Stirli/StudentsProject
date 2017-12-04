using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudentsProject
{
    class IntToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = String.Empty;
            try
            {
                if (value is int val)
                {
                    str = val.ToString();
                    if (val == 11)
                    {
                        str += " лет";
                    }
                    else
                    {
                        char first = str.Last();

                        if (first == '1')
                        {
                            str += " год";
                        }

                        // 0, 5, 6, 7, 8, 9
                        else if (first == '0' || first > '4')
                        {
                            str += " лет";
                        }

                        // 2, 3, 4
                        else if (first > '1')
                        {
                            str += " года";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                str = (e.Message);
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value.ToString();
            str = new Regex("^\\d+").Match(str).Value;
            return int.Parse(str);
        }
    }
}
