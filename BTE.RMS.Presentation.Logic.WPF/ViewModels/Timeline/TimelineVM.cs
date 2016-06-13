using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.Controller;

namespace BTE.RMS.Presentation.Logic.ViewModels.Timeline
{
    public class TimelineVM:WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        #endregion

        #region Properties

        public DateTime NowDate { get; set; }

        public DateTime CalDate { get; set; }

        private string persianyear;
        public string PersianYear
        {
            get
            {
                return persianyear;
            }
            set
            {
                persianyear = value;
                OnPropertyChanged("PersianYear");
            }
        }

        private string persianmonth;
        public string PersianMonth
        {
            get
            {
                return persianmonth;
            }
            set
            {
                persianmonth = value;
                OnPropertyChanged("PersianMonth");
            }
        }

        private string persianday;
        public string PersianDay
        {
            get
            {
                return persianday;
            }
            set
            {
                persianday = value;
                OnPropertyChanged("PersianDay");
            }
        }

        private string persiandaynumber;
        public string PersianDayNumber
        {
            get
            {
                return persiandaynumber;
            }
            set
            {
                persiandaynumber = value;
                OnPropertyChanged("PersianDayNumber");
            }
        }

        private string hijridate;
        public string HijriDate
        {
            get
            {
                return hijridate;
            }
            set
            {
                hijridate = value;
                OnPropertyChanged("HijriDate");
            }
        }

        private string gregoriandate;
        public string GregorianDate
        {
            get
            {
                return gregoriandate;
            }
            set
            {
                gregoriandate = value;
                OnPropertyChanged("GregorianDate");
            }
        }

        public int DayOfWeek { get; set; }

        public int FirstDay { get; set; }
        public CommandViewModel SelectSat
        {
            get
            {
                return new CommandViewModel("انتخاب روز ", new DelegateCommand(Selectsat));
            }
        }
        public CommandViewModel SelectSun
        {
            get
            {
                return new CommandViewModel("انتخاب روز", new DelegateCommand(Selectsun));
            }
        }
        public CommandViewModel SelectMon
        {
            get
            {
                return new CommandViewModel("انتخاب روز", new DelegateCommand(Selectmon));
            }
        }
        public CommandViewModel SelectTue
        {
            get
            {
                return new CommandViewModel("انتخاب روز", new DelegateCommand(Selecttue));
            }
        }
        public CommandViewModel SelectWed
        {
            get
            {
                return new CommandViewModel("انتخاب روز", new DelegateCommand(Selectwed));
            }
        }
        public CommandViewModel SelectThu
        {
            get
            {
                return new CommandViewModel("انتخاب روز", new DelegateCommand(Selectthu));
            }

        }

        public CommandViewModel SelectFri
        {
            get
            {
                return new CommandViewModel("انتخاب روز", new DelegateCommand(Selectfri));
            }
        }

        
        public CommandViewModel PreviousWeek
        {
            get
            {
                return new CommandViewModel("هفته قبل", new DelegateCommand(Previousweek));
            }
        }

        public CommandViewModel NextWeek
        {
            get
            {
                return new CommandViewModel("هفته قبل", new DelegateCommand(Nextweek));
            }
        }

        public CommandViewModel CreateAppointment
        {
            get
            {
                return new CommandViewModel("",new DelegateCommand(Appointment));
            }
        }

        private void Appointment()
        {
            this.controller.ShowAppoinmentView();
        }
        #endregion

        #region WeekDays Properties

        private bool satToday;
        public bool SatToday
        {
            get
            {
                return satToday;
            }
            set
            {
                satToday = value;
                OnPropertyChanged("SatToday");
            }
        }

        private bool satselect;
        public bool SatSelect
        {
            get
            {
                return satselect;
            }
            set
            {
                satselect = value;
                OnPropertyChanged("SatSelect");
            }
        }

        private string satNum;
        public string SatNum
        {
            get
            {
                return satNum;
            }
            set
            {
                this.satNum = value;
                OnPropertyChanged("SatNum");
            }
        }
        private bool sunToday;
        public bool SunToday
        {
            get
            {
                return sunToday;
            }
            set
            {
                sunToday = value;
                OnPropertyChanged("SunToday");
            }
        }

        private bool sunselect;
        public bool SunSelect
        {
            get
            {
                return sunselect;
            }
            set
            {
                sunselect = value;
                OnPropertyChanged("SunSelect");
            }
        }

        private string sunNum;
        public string SunNum
        {
            get
            {
                return sunNum;
            }
            set
            {
                sunNum = value;
                OnPropertyChanged("SunNum");
            }
        }
        private bool monToday;
        public bool MonToday
        {
            get
            {
                return monToday;
            }
            set
            {
                monToday = value;
                OnPropertyChanged("MonToday");
            }
        }

        private bool monselect;
        public bool MonSelect
        {
            get
            {
                return monselect;
            }
            set
            {
                monselect = value;
                OnPropertyChanged("MonSelect");
            }
        }

        private string monNum;
        public string MonNum
        {
            get
            {
                return monNum;
            }
            set
            {
                monNum = value;
                OnPropertyChanged("MonNum");
            }
        }
        private bool tueToday;
        public bool TueToday
        {
            get
            {
                return tueToday;
            }
            set
            {
                tueToday = value;
                OnPropertyChanged("TueToday");
            }
        }

        private bool tueselect;
        public bool TueSelect
        {
            get
            {
                return tueselect;
            }
            set
            {
                tueselect = value;
                OnPropertyChanged("TueSelect");
            }
        }

        private string tueNum;
        public string TueNum
        {
            get
            {
                return tueNum;
            }
            set
            {
                this.tueNum = value;
                OnPropertyChanged("TueNum");
            }
        }
        private bool wedToday;
        public bool WedToday
        {
            get
            {
                return wedToday;
            }
            set
            {
                wedToday = value;
                OnPropertyChanged("WedToday");
            }
        }

        private bool wedselect;
        public bool WedSelect
        {
            get
            {
                return wedselect;
            }
            set
            {
                wedselect = value;
                OnPropertyChanged("WedSelect");
            }
        }

        private string wedNum;
        public string WedNum
        {
            get
            {
                return wedNum;
            }
            set
            {
                wedNum = value;
                OnPropertyChanged("WedNum");
            }
        }
        private bool thuToday;
        public bool ThuToday
        {
            get
            {
                return thuToday;
            }
            set
            {
                thuToday = value;
                OnPropertyChanged("ThuToday");
            }
        }

        private bool thuselect;
        public bool ThuSelect
        {
            get
            {
                return thuselect;
            }
            set
            {
                thuselect = value;
                OnPropertyChanged("ThuSelect");
            }
        }

        private string thuNum;
        public string ThuNum
        {
            get
            {
                return thuNum;
            }
            set
            {
                thuNum = value;
                OnPropertyChanged("ThuNum");
            }
        }
        private bool friToday;
        public bool FriToday
        {
            get
            {
                return friToday;
            }
            set
            {
                friToday = value;
                OnPropertyChanged("FriToday");
            }
        }

        private bool friselect;
        public bool FriSelect
        {
            get
            {
                return friselect;
            }
            set
            {
                friselect = value;
                OnPropertyChanged("FriSelect");
            }
        }
        private string friNum;
        public string FriNum
        {
            get
            {
                return friNum;
            }
            set
            {
                friNum = value;
                OnPropertyChanged("FriNum");
            }
        }

        #endregion

        #region Constructors
        public TimelineVM()
        {
            init();
        }

        public TimelineVM(IRMSController rms)
        {
            init();
            this.controller = rms;
        }
        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "قرار های من ";
            this.NowDate = DateTime.Now;
            this.CalDate = NowDate;
            PersianCalendar pc = new PersianCalendar();
            DayOfWeek = pc.GetDayOfYear(NowDate) % 7;
            SelectDefault();
            SetTimes(NowDate);
            SetWeekProperties();
        }
        private void SetTimes(DateTime time)
        {
            GregorianCalendar gc = new GregorianCalendar();
            PersianCalendar pc = new PersianCalendar();
            HijriCalendar hc = new HijriCalendar();
            string Year = ConvertNumbers(gc.GetYear(time));
            string Month = GetMonths(gc.GetMonth(time));
            string Day = ConvertNumbers(gc.GetDayOfMonth(time));
            this.GregorianDate = Day + " " + Month + " " + Year;
            this.PersianYear = ConvertNumbers(pc.GetYear(time));
            this.PersianMonth = ConvertMonths(pc.GetMonth(time));
            this.PersianDay = ConvertDays(time.DayOfWeek.ToString());
            this.PersianDayNumber = ConvertNumbers(pc.GetDayOfMonth(time));
            string HijriYear = ConvertNumbers(hc.GetYear(time));
            string HijriMonth = ConvertHijriMonths(hc.GetMonth(time));
            string HijriDay = ConvertNumbers(hc.GetDayOfMonth(time));
            this.HijriDate = HijriDay + " " + HijriMonth + " " + HijriYear;

        }

        private void SetWeekProperties()
        {
            PersianCalendar pc = new PersianCalendar();
            int dayofWeek = pc.GetDayOfYear(CalDate) % 7;
            int dayofMonth = pc.GetDayOfMonth(CalDate);
            TimeSpan time = this.NowDate - CalDate;
            int difference = Math.Abs(time.Days);
            Console.WriteLine(difference);
            ResetToday();
            SelectDefault();
            if (difference + DayOfWeek <= 7) { SetToday(); }
            FirstDay = dayofMonth - dayofWeek;
            DateTime fake = CalDate;
            fake -= TimeSpan.FromDays(dayofWeek);
            SatNum = ConvertNumbers(TakePersianDate(fake, 0));
            SunNum = ConvertNumbers(TakePersianDate(fake, 1));
            MonNum = ConvertNumbers(TakePersianDate(fake, 2));
            TueNum = ConvertNumbers(TakePersianDate(fake, 3));
            WedNum = ConvertNumbers(TakePersianDate(fake, 4));
            ThuNum = ConvertNumbers(TakePersianDate(fake, 5));
            FriNum = ConvertNumbers(TakePersianDate(fake, 6));

        }

        private int TakePersianDate(DateTime timer, int diff)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime fake = timer;
            fake += TimeSpan.FromDays(diff);
            return pc.GetDayOfMonth(fake);
        }


        private void ResetToday()
        {
            SatToday = false;
            SunToday = false;
            MonToday = false;
            TueToday = false;
            WedToday = false;
            ThuToday = false;
            FriToday = false;
        }

        private void SetToday()
        {
            switch (DayOfWeek)
            {
                case 0:
                    this.SatToday = true;
                    break;
                case 1:
                    this.SunToday = true;
                    break;
                case 2:
                    this.MonToday = true;
                    break;
                case 3:
                    this.TueToday = true;
                    break;
                case 4:
                    this.WedToday = true;
                    break;
                case 5:
                    this.ThuToday = true;
                    break;
                case 6:
                    this.FriToday = true;
                    break;
            }
        }

        private void SelectDefault()
        {
            SatSelect = false;
            SunSelect = false;
            MonSelect = false;
            TueSelect = false;
            WedSelect = false;
            ThuSelect = false;
            FriSelect = false;
        }

        private void Nextweek()
        {
            CalDate += TimeSpan.FromDays(7);
            SetWeekProperties();
        }

        private void Previousweek()
        {
            CalDate -= TimeSpan.FromDays(7);
            SetWeekProperties();
        }


        private void Selectsat()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 0;
            Selected -= TimeSpan.FromDays(diffrence);
            SetTimes(Selected);
            SelectDefault();
            SatSelect = true;

        }

        private void Selectsun()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 1;
            if (diffrence >= 0)
                Selected -= TimeSpan.FromDays(diffrence);
            else
                Selected += TimeSpan.FromDays(-diffrence);
            SetTimes(Selected);
            SelectDefault();
            SunSelect = true;
        }
        private void Selectmon()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 2;
            if (diffrence >= 0)
                Selected -= TimeSpan.FromDays(diffrence);
            else
                Selected += TimeSpan.FromDays(-diffrence);
            SetTimes(Selected);
            SelectDefault();
            MonSelect = true;
        }
        private void Selecttue()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 3;
            if (diffrence >= 0)
                Selected -= TimeSpan.FromDays(diffrence);
            else
                Selected += TimeSpan.FromDays(-diffrence);
            SetTimes(Selected);
            SelectDefault();
            TueSelect = true;
        }
        private void Selectwed()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 4;
            if (diffrence >= 0)
                Selected -= TimeSpan.FromDays(diffrence);
            else
                Selected += TimeSpan.FromDays(-diffrence);
            SetTimes(Selected);
            SelectDefault();
            WedSelect = true;
        }
        private void Selectthu()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 5;
            if (diffrence >= 0)
                Selected -= TimeSpan.FromDays(diffrence);
            else
                Selected += TimeSpan.FromDays(-diffrence);
            SetTimes(Selected);
            SelectDefault();
            ThuSelect = true;
        }
        private void Selectfri()
        {
            DateTime Selected = CalDate;
            int diffrence = DayOfWeek - 6;
            if (diffrence >= 0)
                Selected -= TimeSpan.FromDays(diffrence);
            else
                Selected += TimeSpan.FromDays(-diffrence);
            SetTimes(Selected);
            SelectDefault();
            FriSelect = true;
        }
        #endregion     

        #region Public Method
        public void Load()
        {

        }
        #endregion

        #region Convert to Persian
        private string ConvertNumbers(int number)
        {
            string results = "";
            string check = number.ToString();
            char[] check_arr = check.ToCharArray(0, check.Length);
            for (int i = 0; i < check_arr.Length; i++)
            {
                char num = check_arr[i];
                switch (num)
                {
                    case '0':
                        results += "۰";
                        break;
                    case '1':
                        results += "۱";
                        break;
                    case '2':
                        results += "۲";
                        break;
                    case '3':
                        results += "۳";
                        break;
                    case '4':
                        results += "۴";
                        break;
                    case '5':
                        results += "۵";
                        break;
                    case '6':
                        results += "۶";
                        break;
                    case '7':
                        results += "۷";
                        break;
                    case '8':
                        results += "۸";
                        break;
                    case '9':
                        results += "۹";
                        break;
                }
            }
            return results;
        }

        private string ConvertDays(string day)
        {
            string result = "";
            switch (day)
            {
                case "Saturday":
                    result = "شنبه";
                    break;
                case "Sunday":
                    result = "یکشنبه";
                    break;
                case "Monday":
                    result = "دوشنبه";
                    break;
                case "Tuesday":
                    result = "سه شنبه";
                    break;
                case "Wednesday":
                    result = "چهارشنبه";
                    break;
                case "Thursday":
                    result = "پنج شنبه";
                    break;
                case "Friday":
                    result = "جمعه";
                    break;
            }
            return result;
        }

        private string ConvertMonths(int mon)
        {
            string result = "";
            switch (mon)
            {
                case 1:
                    result = "فروردین";
                    break;
                case 2:
                    result = "اردیبهشت";
                    break;
                case 3:
                    result = "خرداد";
                    break;
                case 4:
                    result = "تیر";
                    break;
                case 5:
                    result = "مرداد";
                    break;
                case 6:
                    result = "شهریور";
                    break;
                case 7:
                    result = "مهر";
                    break;
                case 8:
                    result = "آبان";
                    break;
                case 9:
                    result = "آذر";
                    break;
                case 10:
                    result = "دی";
                    break;
                case 11:
                    result = "بهمن";
                    break;
                case 12:
                    result = "اسفند";
                    break;
            }
            return result;
        }
        #endregion

        #region Convert to Hijri
        private string ConvertHijriMonths(int mon)
        {
            string result = "";
            switch (mon)
            {
                case 1:
                    result = "محرم";
                    break;
                case 2:
                    result = "صفر";
                    break;
                case 3:
                    result = "ربیع‌الاول";
                    break;
                case 4:
                    result = "ربیع‌الثانی";
                    break;
                case 5:
                    result = "جمادی‌الاول";
                    break;
                case 6:
                    result = "جمادی‌الثانی";
                    break;
                case 7:
                    result = "رجب";
                    break;
                case 8:
                    result = "شعبان";
                    break;
                case 9:
                    result = "رمضان";
                    break;
                case 10:
                    result = "شوال";
                    break;
                case 11:
                    result = "ذیقعده";
                    break;
                case 12:
                    result = "ذیحجه";
                    break;
            }
            return result;
        }
        #endregion

        #region Gregorian Months
        private string GetMonths(int mon)
        {
            string result = "";
            switch (mon)
            {
                case 1:
                    result = "ژانویه";
                    break;
                case 2:
                    result = "فوریه";
                    break;
                case 3:
                    result = "مارس";
                    break;
                case 4:
                    result = "آوریل";
                    break;
                case 5:
                    result = "مه";
                    break;
                case 6:
                    result = "ژوئن";
                    break;
                case 7:
                    result = "ژوئیه";
                    break;
                case 8:
                    result = "اوت";
                    break;
                case 9:
                    result = "سپتامبر";
                    break;
                case 10:
                    result = "اکتبر";
                    break;
                case 11:
                    result = "نوامبر";
                    break;
                case 12:
                    result = "دسامبر";
                    break;
            }
            return result;
        }
        #endregion
    }
}
