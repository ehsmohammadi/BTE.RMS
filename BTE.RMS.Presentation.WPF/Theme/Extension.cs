using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTE.RMS.Presentation.Theme
{
    public class Extension
    {
        public static readonly DependencyProperty IsSelectedProperty =
        DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(Extension), null);

        public static void SetIsSelected(UIElement element, bool value)
        {
            element.SetValue(IsSelectedProperty, value);
        }

        public static bool GetIsSelected(UIElement element)
        {
            return (bool)element.GetValue(IsSelectedProperty);
        }



        public static readonly DependencyProperty TodayProperty =
        DependencyProperty.RegisterAttached("Today", typeof(bool), typeof(Extension), null);

        public static void SetToday(UIElement element, bool value)
        {
            element.SetValue(TodayProperty, value);
        }

        public static bool GetToday(UIElement element)
        {
            return (bool)element.GetValue(TodayProperty);
        }

        public static readonly DependencyProperty BorderSelectProperty =
        DependencyProperty.RegisterAttached("BorderSelect", typeof(bool), typeof(Extension), null);

        public static void SetBorderSelect(UIElement element, bool value)
        {
            element.SetValue(BorderSelectProperty, value);
        }

        public static bool GetBorderSelect(UIElement element)
        {
            return (bool)element.GetValue(BorderSelectProperty);
        }
    }
}
