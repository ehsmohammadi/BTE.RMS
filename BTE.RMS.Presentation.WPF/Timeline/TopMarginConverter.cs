using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BTE.RMS.Presentation.Timeline
{
    public class TopMarginConverter:IMultiValueConverter
    {
        #region IValueConverter Members

        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double topValue = (double)value[0];
            double leftValue = (double) value[1];
            return new Thickness(leftValue, topValue, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
