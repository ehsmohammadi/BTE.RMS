using System.Collections.ObjectModel;
using System.ComponentModel;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;
using BTE.RMS.Presentation.WPF.Models;

namespace BTE.RMS.Presentation.WPF.ViewModels
{
    public class OveralObjectiveViewModel : INotifyPropertyChanged
    {
        #region Private Properties and backfields

        //private ObservableCollection<OveralObjective> ListOveral { get; set; }

        private readonly IOveralObjectiveServiceWrapper overal;

        #endregion


        #region Constructor
        public OveralObjectiveViewModel(IOveralObjectiveServiceWrapper _overal)
        {
            this.overal = _overal;
           
        }
        #endregion



        #region Public Methods

        //public ObservableCollection<OveralObjective> GetData()
        //{
        //    return ListOveral;
        //} 

        //public void SampleData()
        //{
        //    ListOveral = new ObservableCollection<OveralObjective>
        //    {
        //        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/2677.jpg",
        //            Periority = "A",
        //            View = "ورزش"
        //        },
        //        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
        //            Periority = "B",
        //            View = "فوتبال"
        //        },
        //        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
        //            Periority = "B",
        //            View = "والیبال"
        //        },
        //        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
        //            Periority = "B",
        //            View = "بسکتبال"
        //        },
        //        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
        //            Periority = "B",
        //            View = "هندبال"
        //        },
        //                        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
        //            Periority = "B",
        //            View = "هندبال"
        //        },
        //                        new OveralObjective
        //        {
        //            AsTarget = "سلامتی و تندرستی",
        //            ExplainGoal = "سلامت و تندرستی من شامل رژیم و تغذیه، انرژی، تنفس صحیح و نیروی فیزیکی و ...",
        //            Image = "E:/مباهله/6930588-foggy-night-bridge-street-lights.jpg",
        //            Periority = "B",
        //            View = "هندبال"
        //        },
        //    };
            
        //}

        #endregion



        #region INotifyPropertyChange

        #region Delegates and Events(1)

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
