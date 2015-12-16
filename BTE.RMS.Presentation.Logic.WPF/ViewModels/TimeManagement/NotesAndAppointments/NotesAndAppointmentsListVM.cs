using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class NotesAndAppointmentsListVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly INotesAndAppointmentsServiceWrapper notesAndAppointmentsService;

        #endregion

        #region Properties & BackFields
        //private ObservableCollection<FilteringNotesAndAppointments> calendarFilter=new ObservableCollection<FilteringNotesAndAppointments>
        //{
        //    new FilteringNotesAndAppointments
        //    {
        //        Filter = "تمام یادداشت ها وقرار های ملاقات"
        //    },            
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "تمام یادداشت ها"
        //    },  
        //                            new FilteringNotesAndAppointments
        //    {
        //        Filter = "تمام قرارهای ملاقات"
        //    }
        //};

        //public ObservableCollection<FilteringNotesAndAppointments> CalendarFilter
        //{
        //    get { return calendarFilter; }
        //    set { this.SetField(p=>p.CalendarFilter,ref calendarFilter,value);}
        //}

        //private FilteringNotesAndAppointments selectedCalendarFilter;

        //public FilteringNotesAndAppointments SelectedCalendarFilter
        //{
        //    get { return selectedCalendarFilter; }
        //    set { this.SetField(p => p.SelectedCalendarFilter, ref selectedCalendarFilter, value); }
        //}
        //private ObservableCollection<FilteringNotesAndAppointments> tableFilter = new ObservableCollection<FilteringNotesAndAppointments>
        //{
        //    new FilteringNotesAndAppointments
        //    {
        //        Filter = "تمام یادداشت ها وقرار های ملاقات"
        //    },            
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "تمام یادداشت ها"
        //    },     
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "یادداشت های انجام شده"
        //    },     
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "یادداشت های انجام نشده"
        //    },     
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "تمام قرارهای ملاقات"
        //    },     
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "قرارهای ملاقات انجام شده"
        //    },     
        //                new FilteringNotesAndAppointments
        //    {
        //        Filter = "قرارهای ملاقات انجام نشده"
        //    },     
        //};

        //public ObservableCollection<FilteringNotesAndAppointments> TableFilter
        //{
        //    get { return tableFilter; }
        //    set { this.SetField(p => p.TableFilter, ref  tableFilter, value); }
        //}

        //private FilteringNotesAndAppointments selectedTableFilter;

        //public FilteringNotesAndAppointments SelectedTableFilter
        //{
        //    get { return selectedTableFilter; }
        //    set { this.SetField(p => p.SelectedTableFilter, ref selectedTableFilter, value); }
        //}

        private ObservableCollection<NoteAndAppointment> notesAndAppointments;

        public ObservableCollection<NoteAndAppointment> NotesAndAppointments
        {
            get { return notesAndAppointments; }
            set
            {
                this.SetField(p => p.NotesAndAppointments, ref notesAndAppointments, value);
            }
        }

        private NoteAndAppointment selectedNotesAndAppointments;

        public NoteAndAppointment SelectedNotesAndAppointments
        {
            get { return selectedNotesAndAppointments; }
            set
            {
                this.SetField(p => p.SelectedNotesAndAppointments, ref selectedNotesAndAppointments, value);
            }
        }
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("یادداشت/قرار ملاقات جدید", new DelegateCommand(create));
                }
                return createCmd;
            }
        }

        private CommandViewModel modifyCmd;
        public CommandViewModel ModifyCmd
        {
            get
            {
                if (modifyCmd == null)
                {
                    modifyCmd = new CommandViewModel("ویرایش", new DelegateCommand(modify));
                }
                return modifyCmd;
            }
        }

        private CommandViewModel deleteCmd;
        public CommandViewModel DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    deleteCmd = new CommandViewModel("حذف", new DelegateCommand(delete));
                }
                return deleteCmd;
            }
        }

        #endregion

        #region Constructors

        public NotesAndAppointmentsListVM()
        {
            init();
        }

        public NotesAndAppointmentsListVM(IRMSController controller,INotesAndAppointmentsServiceWrapper notesAndAppointmentsService)
        {
            this.controller = controller;
            this.notesAndAppointmentsService = notesAndAppointmentsService;
            init();
        }
        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها/قرار ملاقات";
            NotesAndAppointments = new ObservableCollection<NoteAndAppointment>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void create()
        {
            controller.ShowNotesAndAppointmentsView();
        }

        public void modify()
        {
            controller.ShowNotesAndAppointmentsView();
        }
        public void delete()
        {
            controller.ShowNotesAndAppointmentsView();
        }
        #endregion

        #region Public Methods
        public void Load()
        {
            notesAndAppointmentsService.GetAllOveralObjectives(
                (res, exp) => 
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        NotesAndAppointments = new ObservableCollection<NoteAndAppointment>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
