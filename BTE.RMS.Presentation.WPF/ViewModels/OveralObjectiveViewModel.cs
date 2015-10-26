using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Presentation.WPF.Models;

namespace BTE.RMS.Presentation.WPF.ViewModels
{
    public class OveralObjectiveViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<OveralObjective> _overal { get; set; }
        public OveralObjective AddOveralObjective { get; set; }
        #endregion

        #region Constructors
        private void SampleData()
        {
            _overal = new ObservableCollection<OveralObjective>
            {
                new OveralObjective
                {
                    AsTarget = "سلامتی و تندرستی",
                    ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
                    Image = "E:/مباهله/2677.jpg",
                    Periority = "A",
                    View = "ورزش"
                },
                new OveralObjective
                {
                    AsTarget = "سلامتی و تندرستی",
                    ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
                    Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
                    Periority = "B",
                    View = "فوتبال"
                },
                new OveralObjective
                {
                    AsTarget = "سلامتی و تندرستی",
                    ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
                    Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
                    Periority = "B",
                    View = "والیبال"
                },
                new OveralObjective
                {
                    AsTarget = "سلامتی و تندرستی",
                    ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
                    Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
                    Periority = "B",
                    View = "بسکتبال"
                },
                new OveralObjective
                {
                    AsTarget = "سلامتی و تندرستی",
                    ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
                    Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
                    Periority = "B",
                    View = "هندبال"
                },
            };
            AddOveralObjective = new OveralObjective();
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
