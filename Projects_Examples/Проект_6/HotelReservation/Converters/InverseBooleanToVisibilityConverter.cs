using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelReservation.Converters;

/// <summary> Конвертор булевой логики для реализации задержки загрузки UI </summary>
public class InverseBooleanToVisibilityConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return value is bool boolValue && boolValue ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
