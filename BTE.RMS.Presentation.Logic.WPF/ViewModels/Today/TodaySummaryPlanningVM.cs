﻿using System;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.Controller;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class TodaySummaryPlanningVM:WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller; 
        #endregion

        #region Properties & Back fields

        private DateTime toDayDate;
        public DateTime ToDayDate
        {
            get { return toDayDate; }
            set
            {
                this.SetField(p => p.ToDayDate, ref toDayDate, value);
                ToDayDatestr = toDayDate.ToLongDateString() +"-"+ toDayDate.ToLongTimeString();
            }
        }

        private string toDayDatestr;
        public string ToDayDatestr
        {
            get { return toDayDatestr; }
            set { this.SetField(p => p.ToDayDatestr, ref toDayDatestr, value); }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Design time constructor
        /// </summary>
        public TodaySummaryPlanningVM()
        {
            init();
        }

        public TodaySummaryPlanningVM(IRMSController controller)
        {
            this.controller = controller;
            init();
        } 
        #endregion

        #region Private Mehtods
        private void init()
        {
            DisplayName = "خلاصه برنامه امروز";
            ToDayDate = DateTime.Now;
        } 
        #endregion
    }
}
