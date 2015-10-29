using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;
using BTE.RMS.Presentation.WPF.Models;
using BTE.RMS.Presentation.WPF.Views;

namespace BTE.RMS.Presentation.WPF.ViewModels
{
    public class OveralObjectiveViewModel : INotifyPropertyChanged
    {
        #region Private Properties and backfields

        //private ObservableCollection<OveralObjective> ListOveral { get; set; }

        private readonly IOveralObjectiveServiceWrapper _overal;
        private  OveralObjectiveServiceWrapper overalObjectiveServiceWrapper=new OveralObjectiveServiceWrapper();
        private  NewOveralObjective newOveralObjective=new NewOveralObjective();

        #endregion
        
        #region Constructor
        public OveralObjectiveViewModel(IOveralObjectiveServiceWrapper overal)
        {
            this._overal = overal;
            
        }
        #endregion



        #region Public Methods

        public void addtolist()
        {
           overalObjectiveServiceWrapper.CreateOveralObjective(newOveralObjective);
           CrudOveralObjective crud=new CrudOveralObjective();
            crud.AsTarget = newOveralObjective.txtastarget;
            crud.ExplainGoal = newOveralObjective.txtexplaingoal;
            crud.Periority = newOveralObjective.periority;
            crud.Image = newOveralObjective.image1.ToString();
            crud.View = newOveralObjective.txtview.ToString();

        }
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
