﻿using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class OveralObjectiveVm:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly IOveralObjectiveServiceWrapper overalObjectiveService;
        #endregion
        #region Properties & BackFields

        private ObservableCollection<PeriorityType> periorityTypeList;

        public ObservableCollection<PeriorityType> PeriorityTypeList
        {
            get { return periorityTypeList; }
            set { this.SetField(p=>p.PeriorityTypeList,ref periorityTypeList,value);}
        }

        private PeriorityType selectedPeriorityType;

        public PeriorityType SelectedPeriorityType
        {
            get { return selectedPeriorityType; }
            set { this.SetField(p=>p.SelectedPeriorityType,ref selectedPeriorityType,value);}
        }
        private CrudOveralObjective overalObjective;

        public CrudOveralObjective OveralObjective
        {
            get { return overalObjective; }
            set { this.SetField(p=>p.OveralObjective,ref overalObjective,value);}
        }
        private CommandViewModel registerCmd;
        public CommandViewModel RegisterCmd
        {
            get
            {
                if (registerCmd == null)
                {
                    registerCmd = new CommandViewModel("ثبت", new DelegateCommand(register));
                }
                return registerCmd;
            }
        }
        private CommandViewModel backCmd;
        public CommandViewModel BackCmd
        {
            get
            {
                if (backCmd == null)
                {
                    backCmd = new CommandViewModel("بازگشت", new DelegateCommand(back));
                }
                return backCmd;
            }
        }
        #endregion
        #region Constructors

        public OveralObjectiveVm()
        {
            init();
        }

        public OveralObjectiveVm(IRMSController controller, IOveralObjectiveServiceWrapper overalObjectiveService)
        {
            this.controller = controller;
            this.overalObjectiveService = overalObjectiveService;
            init();
        }

        #endregion
        #region Private Methods
        private void init()
        {
            DisplayName = "اهداف کلی";
            PeriorityTypeList=new ObservableCollection<PeriorityType>();
            OveralObjective=new CrudOveralObjective();
        }
        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            //libraryService.CreateCrudDailyShortTip((res, exp) =>
            //{
            //    HideBusyIndicator();
            //    if (exp == null)
            //    {
            //        CrudLibrary = new CrudLibrary();
            //    }
            //    else
            //    {
            //        controller.HandleException(exp);
            //    }
            //}, CrudLibrary);
            overalObjectiveService.CreateOveralObjective(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OveralObjective=new CrudOveralObjective();
                    }
                    else controller.HandleException(exp);
                },OveralObjective);
            //overalObjectiveService.CreateOveralObjective(
            //(res, exp) =>
            //{
            //    HideBusyIndicator();
            //    if (exp == null)
            //    {
            //        OveralObjective = new CrudOveralObjective();
            //    }
            //    else
            //    {
            //        controller.HandleException(exp);
            //    }
            //},OveralObjective);
            controller.ShowOveralObjectiveListView();
        }
        private void back()
        {
            controller.ShowOveralObjectiveListView();
        }
        #endregion
        #region Public Methods

        public void Load()
        {
            overalObjectiveService.PeriorityTypeList((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    PeriorityTypeList=new ObservableCollection<PeriorityType>(res);
                }
                else
                {
                    controller.HandleException(exp);
                }
            });
        }
        #endregion
    }
}
