using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Controls;

namespace BTE.RMS.Presentation.Timeline.Control
{
    /// <summary>
    /// Interaction logic for Appoint.xaml
    /// </summary>
    public partial class Appoint : UserControl, INotifyPropertyChanged
    {
        
        public Appoint()
        {
            InitializeComponent();
            this.DataContext = this;
            Selected = false;
            Title = GetSubject(this);
        }

        private string title;

        public string Title
        {
            get
            {
                return title;
                
            }
            set
            {
                title = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }
        private bool selected;

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                Console.WriteLine(Selected);
                OnPropertyChanged(new PropertyChangedEventArgs("Selected"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        public static readonly DependencyProperty IsSelectedProperty =
       DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(Appoint), null);

        public static void SetIsSelected(UIElement element, bool value)
        {
            element.SetValue(IsSelectedProperty, value);
        }

        public static bool GetIsSelected(UIElement element)
        {
            return (bool)element.GetValue(IsSelectedProperty);
        }

        public static readonly DependencyProperty SubjectProperty =
        DependencyProperty.RegisterAttached("Subject", typeof(string), typeof(Appoint), null);

        public static void SetSubject(UIElement element, string value)
        {
            element.SetValue(SubjectProperty, value);
        }

        public static string GetSubject(UIElement element)
        {
            return (string)element.GetValue(SubjectProperty);
        }
    }
}
