﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace MaterialForms.Wpf.Resources.ValueConverters
{
    public class AsBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool b && b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
