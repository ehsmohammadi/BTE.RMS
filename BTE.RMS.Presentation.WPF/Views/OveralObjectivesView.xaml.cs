using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using  System.Windows.Controls;
using BTE.RMS.Presentation.WPF.Models;

namespace BTE.RMS.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for OveralObjectives.xaml
    /// </summary>
    public partial class OveralObjectives : Window
    {
        private ObservableCollection<OveralObjective> overal { get; set; }

        //public ObservableCollection<OveralObjective> Ov
        //{
        //    get
        //    {
        //        return Overal;
        //    }
        //}
        public OveralObjectives()
        {
            InitializeComponent();
            
            //OveralObjectiveViewModel obv = new OveralObjectiveViewModel();
            //obv.SampleData();
            //overal = obv.GetData();
            //DataGrid1.DataContext = overal;
            //OveralObjectiveViewModel obv=new OveralObjectiveViewModel();
        }

        private void Btn_AddNewOveralObjectives_Click(object sender, RoutedEventArgs e)
        {
            NewOveralObjective obv=new NewOveralObjective();
            obv.Show();
        }
    }
}
