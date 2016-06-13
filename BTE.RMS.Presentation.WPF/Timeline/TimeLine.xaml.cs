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
using BTE.RMS.Presentation.Logic.Views;
using BTE.RMS.Presentation.Logic.WPF.Views;
using ViewBase = BTE.Presentation.UI.WPF.ViewBase;

namespace BTE.RMS.Presentation.Timeline
{
    /// <summary>
    /// Interaction logic for TimeLine.xaml
    /// </summary>
    public partial class TimeLine : ViewBase, ITimeline
    {
        public TimeLine()
        {
            InitializeComponent();
        }
    }
}
