﻿using System;
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
using Microsoft.Win32;

namespace BTE.RMS.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for OveralObjectiveView.xaml
    /// </summary>
    public partial class OveralObjectiveView : Page
    {
        public OveralObjectiveView()
        {
            InitializeComponent();
        }

        private void addimage_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog op=new OpenFileDialog();
            //op.Filter = "JPEG|*.jpg|PNG|*.png";
            //op.FileName = "Untitled";
            //op.Title = "Select Your Image...";
            //op.ShowDialog();
            //listbox1.Items.Add(op.FileName);
            //image1.Source = new BitmapImage(new Uri(op.FileName));
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
    }
}
