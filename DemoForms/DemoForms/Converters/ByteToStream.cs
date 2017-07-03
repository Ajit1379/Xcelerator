using System;
using System.Globalization;
using Xamarin.Forms;

namespace DemoForms.Converters
{
    using DemoForms.Helpers;

    class ByteToStream : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return ImageSource.FromStream(() => ImageHelper.ByteToStream((byte[])value));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
