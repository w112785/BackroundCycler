﻿using System;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace Backround_Cycler.WPF.Controls
{
    [ValueConversion (typeof (bool), typeof (Visibility))]
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }

        public BooleanToVisibilityConverter ()
        {
            // set defaults
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Collapsed;
        }

        public object Convert (object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return null;
            return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack (object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (Equals (value, TrueValue))
                return true;
            if (Equals (value, FalseValue))
                return false;
            return null;
        }
    }

}
