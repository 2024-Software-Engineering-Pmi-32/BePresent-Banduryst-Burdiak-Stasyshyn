// StringToVisibilityConverter.cs
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace bepresent_wpf.Presentation // Змінено простір імен
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && string.IsNullOrWhiteSpace(str))
            {
                return Visibility.Visible; // Показати, якщо рядок порожній
            }
            return Visibility.Collapsed; // Приховати, якщо не порожній
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
