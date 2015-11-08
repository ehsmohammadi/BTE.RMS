using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BTE.Presentation;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.WPF.Views;
using BTE.RMS.Presentation.WPF.EducationManagement;
using BTE.RMS.Presentation.WPF.QuranAndPrayer;
using BTE.RMS.Presentation.WPF.Today;
using BTE.RMS.Presentation.WPF.Views;

namespace BTE.RMS.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowViewBase, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //var page = new OveralObjectiveListView();
            //mainFrame.Navigate(page);
        }

        public ContentPresenter ContentPresenter
        {
            get
            {
                return Content;
            }
            set
            {
                Content = value;
            }
        }
    }
}
