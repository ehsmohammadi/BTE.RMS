using System.Windows.Controls;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.WPF.Views;

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
