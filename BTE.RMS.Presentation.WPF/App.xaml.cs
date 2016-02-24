﻿using System;
using System.Windows;
using BTE.Core;
using BTE.Presentation;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic;
using BTE.RMS.Presentation.Logic.WPF;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.WPF
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
            

        }

        private void App_Exit(object sender, ExitEventArgs e)
        {

        }


        #endregion


    }
}
