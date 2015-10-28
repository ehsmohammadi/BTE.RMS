using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using BTE.RMS.Presentation.WPF.Models;
using BTE.RMS.Presentation.WPF.Views;

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
            var mainWindow = new OveralObjectives();
            mainWindow.Show();
            //Application.Current.MainWindow = new OveralObjectives();
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {

        } 


        #endregion


    }
}
