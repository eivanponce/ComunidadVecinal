using System.Globalization;

namespace ComunidadVecinal.Converters
{
    public class IngresoColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            bool esIngreso = ((CheckBox)parameter!).IsChecked;
            decimal cantidad = (decimal)value!;
            return (esIngreso) ? (Color)Color.FromRgba("#4CAF50") : Color.FromRgba("#CD5C5C");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
