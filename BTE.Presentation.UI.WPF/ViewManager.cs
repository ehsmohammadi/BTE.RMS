using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace BTE.Presentation.UI.WPF
{
    public static class Extensions
    {
        public static T FindParentOfType<T>(this FrameworkElement element)
        {
            //var parent = VisualTreeHelper.GetParent(element) as FrameworkElement;

            //while (parent != null)
            //{
            //    if (parent is T)
            //        return (T)(object)parent;

            //    //parent = VisualTreeHelper.GetParent(parent) as FrameworkElement;
            //}
            return default(T);
        }
    }

    public class ViewManager : IViewManager
    {
        #region Fields

        private static Dispatcher dispatcher;
        private static bool? _designer;
        private TabControl tc;
        private DataTemplate tabHeaderTemplate;
        //private BusyIndicator busyIndicatorObject;
        //private BusyIndicatorVM busyIndicatorVM = new BusyIndicatorVM(); 

        #endregion

        #region Properties

        public static bool IsInDesignTool
        {
            get
            {
                return DesignerProperties.IsInDesignModeProperty != null ? true : false;
            }
        }
 
        #endregion

        #region Constructors

        public ViewManager()
        {
        }
 
        #endregion

        #region Private Methods

        private static void RequireInstance()
        {
            if (_designer == null)
            {
                _designer = IsInDesignTool;
            }
            // Design-time is more of a no-op, won't be able to resolve the             
            // dispatcher if it isn't already set in these situations.             
            if (_designer == true)
            {
                return;
            }
            // Attempt to use the RootVisual of the plugin to retrieve a             
            // dispatcher instance. This call will only succeed if the current             
            // thread is the UI thread.             
            try
            {
                dispatcher = Application.Current.Dispatcher;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("The first time SmartDispatcher is used must be from a user interface thread. Consider having the application call Initialize, with or without an instance.", e);
            }
            if (dispatcher == null)
            {
                throw new InvalidOperationException("Unable to find a suitable Dispatcher instance.");
            }
        }

        private static void Initialize(Dispatcher dispatcherParam)
        {
            if (dispatcherParam == null)
            {
                throw new ArgumentNullException("dispatcher");
            }
            dispatcher = dispatcherParam;
            if (_designer == null)
            {
                _designer = IsInDesignTool;
            }
        }

        private static bool CheckAccess()
        {
            if (dispatcher == null)
            {
                RequireInstance();
            }
            return dispatcher.CheckAccess();
        }

        #endregion

        #region Public Methods

        public static void Initialize()
        {
            if (dispatcher == null)
            {
                RequireInstance();
            }
        }

        public void BeginInvokeOnDispatcher(Action action)
        {
            if (dispatcher == null)
            {
                RequireInstance();
            }
            // If the current thread is the user interface thread, skip the             
            // dispatcher and directly invoke the Action.             
            if (dispatcher.CheckAccess() || _designer == true)
            {
                action();
            }
            else { dispatcher.BeginInvoke(action); }
        } 

        #endregion
    }
}
