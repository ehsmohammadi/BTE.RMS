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
using System.Windows.Shapes;
using BTE.RMS.Presentation.WPF.ViewModels;

namespace BTE.RMS.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for OveralObjectives.xaml
    /// </summary>
    public partial class OveralObjectives : Window
    {
        public OveralObjectiveViewModel CurreObjectiveViewModel { get; private set; }
        public OveralObjectives()
        {
            CurreObjectiveViewModel=new OveralObjectiveViewModel();
            InitializeComponent();
        }
    }
}
