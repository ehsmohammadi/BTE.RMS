using System.Windows.Controls;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic;
using BTE.RMS.Presentation.Logic.Views;

namespace BTE.RMS.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for PooyaMenu.xaml
    /// </summary>
    public partial class PooyaMenu : WindowViewBase,IWindow
    {
        public PooyaMenu()
        {
            InitializeComponent();
        }

        public ContentPresenter ContentPresenter
        {
            get
            {
                return (ContentPresenter) Content;
            }
            set
            {
                Content = value;
            }
        }
    }
}
