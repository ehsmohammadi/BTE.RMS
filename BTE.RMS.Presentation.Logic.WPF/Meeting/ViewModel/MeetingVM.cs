using System;
using System.Collections.ObjectModel;
using System.Globalization;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.Meeting.Model;
using BTE.RMS.Presentation.Logic.Meeting.Repository;
using BTE.RMS.Presentation.Logic.Meeting.Services;
using BTE.RMS.Presentation.Logic.WPF.PersianDate;

namespace BTE.RMS.Presentation.Logic.Meeting.ViewModel
{
    public class MeetingVM : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private IMeetingService service;
        private IMeetingRepository repository;
        #endregion

        #region Properties

        private PrimaryMeeting meetingItem;
        public PrimaryMeeting Meeting
        {
            get { return meetingItem; }
            set { this.SetField(p => p.meetingItem, ref meetingItem, value); }
        }
        private string type;
        public string Type
        {
            get
            {
                return type; 
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private string titleError;

        public string TitleError
        {
            get
            {
                return titleError;
            }
            set
            {
                titleError = value;
                OnPropertyChanged("TitleError");
            }
        }

        private PersianDate date;

        public PersianDate Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private string duration;

        public string Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        private string location;

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        private string details;

        public string Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
                OnPropertyChanged("Details");
            }
        }

        private string attendees;

        public string Attendees
        {
            get
            {
                return attendees;
            }
            set
            {
                attendees = value;
                OnPropertyChanged("Attendees");
            }
        }
        private ObservableCollection<string> date_types;
        public ObservableCollection<string> Date_Types
        {
            get
            {
                return date_types;
            }
            set
            {
                this.SetField(p => p.date_types, ref date_types, value); 
            }
        }
        public CommandViewModel SelectType
        {
            get
            {
                return new CommandViewModel("", new DelegateCommand(Selecttype));
            }
        }
        public CommandViewModel ChangeType
        {
            get
            {
                return new CommandViewModel("", new DelegateCommand(Changetype));
            }
        }

        public CommandViewModel CreateMeeting
        {
            get
            {
                return new CommandViewModel("",new DelegateCommand(Create));
            }
        }

        private void Create()
        {
            //MeetingDto meeting = new MeetingDto();
            //if (Type.Equals("کاری"))
            //{
            //    meeting.MeetingType = 0;
            //}
            //else
            //{
            //    meeting.MeetingType = 1;
            //}
            ////meeting.Subject = T;
            //meeting.StartDate = new DateTime(Date.Year,Date.Month,Date.Day,new PersianCalendar());
            //meeting.LocationAddress = Location;
            //meeting.Attendees = Attendees;
            //meeting.Details = Details;
            ////TODO : Must add this object to the static meeting list 

            //Meeting
            service.CreateMeeting(Meeting);
        }
        #endregion

        #region Constructors
        public MeetingVM()
        {
            init();
        }

        public MeetingVM(IRMSController rms,IMeetingService serv , IMeetingRepository repo)
        {
            init();
            this.controller = rms;
            this.service = serv;
            repository = repo;
        }

        
        #endregion

        #region Private Methods
        private void init()
        {
            Meeting = new PrimaryMeeting();
            Date_Types = new ObservableCollection<string>();
            Fill_Combo();
            Date = new PersianDate(DateTime.Now);
        }
        private void Changetype()
        {

        }

        private void Selecttype()
        {
            this.Date_Types.Add("کاری");
            this.Date_Types.Add("غیر کاری");
        }

        private void Fill_Combo()
        {
            this.Date_Types.Add("کاری");
            this.Date_Types.Add("غیر کاری");
        }
        #endregion

    }
}
