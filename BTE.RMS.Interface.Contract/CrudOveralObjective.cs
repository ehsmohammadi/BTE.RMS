using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BTE.RMS.Interface.Contract
{
    public class CrudOveralObjective:INotifyPropertyChanged
    {
        #region Fields

        private long id;
        private string _view;
        private string _astarget;
        private string _periority;
        private string _explaingoal;
        private string _image;
        #endregion

        #region properties

        public long Id
        {
            set
            {
                id = value;
            }
            get { return id; }
        }

        public string View
        {
            set
            {
                _view = value;
            }
            get { return _view; }
        }

        public string AsTarget
        {
            set
            {
                _astarget = value;
            }
            get { return _astarget; }
        }

        public string Periority
        {
            set
            {
                _periority = value;
            }
            get { return _periority; }
        }

        public string ExplainGoal
        {
            set
            {
                _explaingoal = value;
            }
            get { return _explaingoal; }
        }

        public string Image
        {
            set
            {
                _image = value;
            }
            get { return _image; }
        }
        #endregion

        #region INotifyPropertyChange
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
        #endregion
    }
}
