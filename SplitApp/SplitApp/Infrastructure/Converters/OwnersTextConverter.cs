using System;
using System.Collections.Generic;
using System.Globalization;
using SplitApp.Model;
using Xamarin.Forms;

namespace SplitApp.Infrastructure.Converters
{
    public class OwnersTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var owners = value as IList<Owner>;
            if (owners == null) return string.Empty;

            switch (owners.Count)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return owners[0].Name;
                case 2:
                    return $"{owners[0].Name} and {owners[1].Name}";
                default:
                    return $"{owners[0].Name}, {owners[1].Name} and {owners.Count - 2} others";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
