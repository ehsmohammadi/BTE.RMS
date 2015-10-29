using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using BTE.RMS.Presentation.Logic.WPF.Wrappers;
using BTE.RMS.Presentation.WPF.Models;
using BTE.RMS.Presentation.WPF.ViewModels;
using Microsoft.Win32;

namespace BTE.RMS.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for NewOveralObjective.xaml
    /// </summary>
    public partial class NewOveralObjective : Window
    {
        private readonly IOveralObjectiveServiceWrapper _overalObjectiveWrapper;

        public NewOveralObjective()
        {
            InitializeComponent();
        }

        //public void add()
        //{
        //    OveralObjective Model = new OveralObjective()
        //    {
        //        AsTarget = txtastarget.ToString(),
        //        ExplainGoal = txtexplaingoal.ToString(),
        //        Image = image1.ToString(),
        //        Periority = periority.Text.ToString(),
        //        View = txtview.ToString()
        //    };

        //}

        private void addimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPEG|*.jpg|PNG|*.png";
            op.FileName = "Untitled";
            op.Title = "Select Your Image...";
            op.ShowDialog();
            listbox1.Items.Add(op.FileName);
            image1.Source = new BitmapImage(new Uri(op.FileName));
        }



        private void deleteimage_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (listbox1.Items.Count == 0)
            //{
            //    listbox1.Items.Clear();
            //    image1.Source = new BitmapImage();
            //}
            //else
            //{
            //    image1.Source = new BitmapImage(new Uri(listbox1.SelectedItem.ToString()));
            //}

        }

        private void btn_submitInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
