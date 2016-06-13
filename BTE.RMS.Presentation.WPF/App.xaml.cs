using System.Windows;
using BTE.Core;
using BTE.Presentation;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.WPF;

namespace BTE.RMS.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            this.Startup += App_Startup;
            this.Exit += App_Exit;
        }
        #endregion

        #region Application Event

        /// <summary>
        /// app start event for loading main windows and run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            new Bootstrapper().Execute();
            var controller = ServiceLocator.Current.GetInstance<IRMSController>();
            var viewManager = ServiceLocator.Current.GetInstance<IViewManager>();
            ViewManager.Initialize();
            var viewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            var mainWindow = ServiceLocator.Current.GetInstance<IMainWindow>();
            mainWindow.ViewModel = viewModel;
            var window = mainWindow as MainWindow;
            if (window != null)
                viewManager.ContentPresenter = window.ContentPresenter;
            viewManager.ShowMainWindow(mainWindow);
            controller.ShowTimeLineView();
            //var window = ServiceLocator.Current.GetInstance<IWindow>();
            //var viewModel = ServiceLocator.Current.GetInstance<WindowVM>();
            //window.ViewModel = viewModel;
            //var Window2 = window as PooyaMenu;
            //if (window != null)
            //    viewManager.ContentPresenter = Window2.ContentPresenter;
            //viewManager.ShowMainWindow(window);
            //PooyaMenu window2 = new PooyaMenu();
            //window2.ViewModel = new PooyaMenuVM();
            //var First = new MenuPage(window2);
            //First.ViewModel = new PooyaMenuVM();
            //window2.Main.Navigate(First);
            //window2.Show();


        }

        private void App_Exit(object sender, ExitEventArgs e)
        {

        }


        #endregion


    }
}
