using System.Globalization;

namespace ComunidadVecinal.Converters
{
    public class IngresoConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            bool esIngreso = ((CheckBox)parameter!).IsChecked;
            decimal cantidad = (decimal)value!;
            return (esIngreso) ? $"+ {cantidad:C}" : $"- {cantidad:C}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
