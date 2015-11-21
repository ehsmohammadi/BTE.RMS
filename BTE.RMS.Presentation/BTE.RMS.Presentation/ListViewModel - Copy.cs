using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Presentation
{
    public class CalenderVM : WorkspaceViewModel
    {


        #region Properties & Back fields

        private DateTime minDate;
        public DateTime MinDate
        {
            get { return minDate; }
            set
            {
                this.SetField(p => p.MinDate, ref minDate, value);
            }

        }

        private DateTime maxDate;
        public DateTime MaxDate
        {
            get { return maxDate; }
            set
            {
                this.SetField(p => p.MaxDate, ref maxDate, value);
            }

        }

        #endregion

        #region Constructors
        /// <summary>
        /// Design Mode Constructor
        /// </summary>
        public CalenderVM()
        {
            init();


        }

        //public OveralObjectiveListViewModel(IOveralObjectiveServiceWrapper overalObjectiveService, IRMSController controller)
        //{
        //    this.overalObjectiveService = overalObjectiveService;
        //    this.controller = controller;
        //    init();
        //}

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "اهداف کلی";
            minDate = DateTime.Now;
            MaxDate = DateTime.Now.AddMonths(120);
            //OveralObjectives.OnRefresh += (s, args) => Load();
        }

        //protected override void OnRequestClose()
        //{
        //    base.OnRequestClose();
        //    controller.Close(this);
        //}
        #endregion

        #region Public Methods

        public void Load()
        {
            //overalObjectiveService.GetAllOveralObjectives(
            //    (res, exp) => controller.BeginInvokeOnDispatcher(() =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            OveralObjectives = new ObservableCollection<SummeryOveralObjective>(res);
            //        }
            //        else controller.HandleException(exp);
            //    }));
        }

        #endregion

    }
}
