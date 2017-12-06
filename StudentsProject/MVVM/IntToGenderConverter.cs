﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentsProject.MVVM
{
    class IntToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int val)
            {
                return Properties.Settings.Default.Genders[val];
            }
            throw new InvalidOperationException($"Невозможно конвертировать {value?.GetType()}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return Properties.Settings.Default.Genders.IndexOf(str);
            }
            throw new InvalidOperationException($"Невозможно конвертировать {value?.GetType()}");
        }
    }
}
