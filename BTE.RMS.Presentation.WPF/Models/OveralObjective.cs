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
        #region Properties And BackFields

        //BackFields
        private string view;
        private string asTarget;
        private string periority;
        private string explaingoal;
        private string image;

        //Properties
        public string View
        {
            set
            {
                view = value;
                onPropertyChanged("View");
            }
            get { return view; }
        }

        public string AsTarget
        {
            set
            {
                asTarget = value;
                onPropertyChanged("AsTarget");
            }
            get { return asTarget; }
        }

        public string Periority
        {
            set
            {
                periority = value;
                onPropertyChanged("Periority");
            }
            get { return periority; }
        }

        public string ExplainGoal
        {
            set
            {
                explaingoal = value;
                    onPropertyChanged("ExplainGoal");
            }
            get { return explaingoal; }
        }

        public string Image
        {
            set
            {
                image = value;
                onPropertyChanged("image");
            }
            get { return image; }
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
