using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Presentation.WPF.Models
{
    public class OveralObjective : INotifyPropertyChanged
    {
        private int age;
        #region Fields
        private string _view;
        private string _astarget;
        private string _periority;
        private string _explaingoal;
        private string _image;
        #endregion

        #region properties

        public string View
        {
            set
            {
                _view = value;
                if(PropertyChanged==null) return;
                onPropertyChanged("View");
            }
            get { return _view; }
        }

        public string AsTarget
        {
            set
            {
                _astarget = value;
                if(PropertyChanged==null) return;
                onPropertyChanged("AsTarget");
            }
            get { return _astarget; }
        }

        public string Periority
        {
            set
            {
                _periority = value;
                if(PropertyChanged==null) return;
                onPropertyChanged("Periority");
            }
            get { return _periority; }
        }

        public string ExplainGoal
        {
            set
            {
                _explaingoal = value;
                if(PropertyChanged==null) return;
                    onPropertyChanged("ExplainGoal");
            }
            get { return _explaingoal; }
        }

        public string Image
        {
            set
            {
                _image = value;
                if(PropertyChanged==null) return;
                onPropertyChanged("Image");
            }
            get { return _image; }
        }
        #endregion

        #region Delegates and Events (1)

        // Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Delegates and Events

        #region Methods (1)

        // Private Methods (1) 

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods
    }
}
