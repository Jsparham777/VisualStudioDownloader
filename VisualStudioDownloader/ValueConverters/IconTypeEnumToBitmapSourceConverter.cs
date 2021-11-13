using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Globalization;
using VisualStudioDownloader.Dialogs;

namespace VisualStudioDownloader.ValueConverters
{
    /// <summary>
    /// Converts a <see cref="IconType/> to <see cref="BitmapSource"/>
    /// <para>True/Visible False/Collapsed</para>
    /// </summary>
    [ValueConversion(typeof(IconType), typeof(BitmapSource))]
    public class IconTypeEnumToBitmapSourceConverter : IValueConverter
    {

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IconType icon = (IconType)value;

            string iconPath = icon switch
            {
                IconType.Warning => @"/Images/warning.png",
                IconType.Error => @"/Images/error.png",
                IconType.Information => @"/Images/information.png",
                _ => @"/Images/warning.png",
            };

            Uri uri = new(iconPath, UriKind.Relative);
            BitmapImage image = new(uri);
            return image;
        }

        /// <summary>
        /// Converts a value back to the original value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        /// <exception cref="NotSupportedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
