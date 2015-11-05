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
using BTE.RMS.Presentation.WPF.EducationManagement;
using BTE.RMS.Presentation.WPF.Today;
using BTE.RMS.Presentation.WPF.Views;

namespace BTE.RMS.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var page = new OveralObjectiveListView();
            var page = new OveralObjectiveListView();
            mainFrame.Navigate(page);
        }
    }
}
