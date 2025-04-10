using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MaterialDemo.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1F5FE")); // 自己的消息背景颜色
            }
            else
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FAFAFA")); // 他人的消息背景颜色
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
