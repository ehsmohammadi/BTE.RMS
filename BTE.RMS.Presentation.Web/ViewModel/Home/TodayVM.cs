using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Home
{
    public class TodayVM
    {
        [DisplayName("میلادی")]
        public string Date { get; set; }

        [DisplayName("شمسی")]
        public string PersianDate { get; set; }

        [DisplayName("هچری قمری")]
        public string ArabicDate { get; set; }


        [DisplayName("اذان صبح")]
        public string AzanSobh { get; set; }

        [DisplayName("طلوع خورشید")]
        public string Sunrise { get; set; }

        [DisplayName("اذان ظهر")]
        public string AzanZohr { get; set; }

        [DisplayName("غروب خورشید")]
        public string SunDown { get; set; }

        [DisplayName("اذان مغرب")]
        public string AzanMaghreb { get; set; }

        [DisplayName("نیمه شب شرعی")]
        public string MidNight { get; set; }

        [DisplayName("مناسبت های روز")]
        public string TodayEventPersian { get; set; }

        [DisplayName("مناسبت های روز")]
        public string TodayEventArabic { get; set; }


        public TodayVM()
        {
            Date = DateTime.Now.ToLongDateString();
            PersianDate = new PersianDateTime(DateTime.Now).ToLongDateString();
            ArabicDate = ToPersianDigit(DateTime.Now.ToString("dddd،d MMMM yyyy", new CultureInfo("ar-SA")));
            var hijri = new HijriCalendar();
            var prayerTime=new Prayer_times();
            prayerTime.SetGeo(51.4382527, 35.6750828, new PersianDateTime(DateTime.Now).Month, new PersianDateTime(DateTime.Now).Day);
            AzanSobh = ToPersianDigit(prayerTime.GetAzanSobh());
            Sunrise = ToPersianDigit(prayerTime.GetTolue());
            AzanZohr = ToPersianDigit(prayerTime.GetAzanZohr());
            SunDown = ToPersianDigit(prayerTime.GetGhorub());
            AzanMaghreb = ToPersianDigit(prayerTime.GetAzanMaghreb());
            MidNight = ToPersianDigit(prayerTime.GetNimehShab());
            TodayEventPersian = GetPersianEvent(new PersianDateTime(DateTime.Now).Month,
                new PersianDateTime(DateTime.Now).Day);
            TodayEventArabic = GetArabicEvent(hijri.GetMonth(DateTime.Now), hijri.GetDayOfMonth(DateTime.Now));
            

        }

        private string GetArabicEvent(int month, int day)
        {
            string EventName = "";
            switch (month)
            {
                case 1:
                    switch (day)
                    {
                        case 1: EventName = "آغاز سال جدید قمری"; break;
                        case 9: EventName = "تاسوعای حسینی -- تعطیل"; break;
                        case 10: EventName = "عاشورای حسینی -- تعطیل"; break;
                        case 12: EventName = " شهادت حضرت زین العابدین ع"; break;
                        case 18: EventName = "تغییر قبله مسلمین از بیت المقدس به مکه"; break;
                        case 25: EventName = "شهادت امام زین العابدین علیه السلام به روایتی"; break;
                    }
                    break;
                case 2:
                    switch (day)
                    {
                        case 3: EventName = "ولادت حضرت امام محمد باقر ع"; break;
                        case 7: EventName = "ولادت حضرت امام موسی کاظم ع"; break;
                        case 20: EventName = "اربعین حسینی -- تعطیل"; break;
                        case 28: EventName = "رحلت حضرت رسول اکرم ص - شهادت حضرت امام حسن مجتبی ع -- تعطیل"; break;
                        case 30: EventName = "شهادت حضرت امام رضا ع - تعطیل"; break;
                    }
                    break;
                case 3:
                    switch (day)
                    {
                        case 1: EventName = "هجرت حضرت رسول ص از مکه به مدینه - مبداگاه شماری هجری قمری"; break;
                        case 8: EventName = "شهادت حضرت امام حسن عسگری ع"; break;
                        case 12: EventName = "میلاد حضرت رسول اکرم به روایت اهل سنت - آغاز هفته وحدت"; break;
                        case 17: EventName = "میلاد حضرت رسول اکرم و روز اخلاق و مهرورزی -- میلاد امام جعفر صادق -- تعطیل"; break;
                    }
                    break;
                case 4:
                    switch (day)
                    {
                        case 8: EventName = "ولادت امام حسن عسکری علیه السلام"; break;
                        case 10: EventName = "(وفات حضرت معصومه (س"; break;
                    }
                    break;
                case 5:
                    switch (day)
                    {
                        case 5: EventName = "ولادت حضرت زینب س - روز پرستار و بهورز"; break;
                    }
                    break;
                case 6:
                    switch (day)
                    {
                        case 3: EventName = "شهادت حضرت فاطمه زهرا س -- تعطیل"; break;
                        case 30: EventName = "ولادت حضرت فاطمه زهرا - ولادت حضرت امام خمینی"; break;
                    }
                    break;
                case 7:
                    switch (day)
                    {
                        case 1: EventName = "ولادت حضرت امام محمد باقر"; break;
                        case 3: EventName = "شهادت حضرت امام علی النقی الهادی "; break;
                        case 10: EventName = "ولادت حضرت امام محمد تقی ع جواد الائمه"; break;
                        case 13: EventName = "ولادت حضرت امام علی  علیه السلام - آغاز ایام اعتکاف -- تعطیل"; break;
                        case 15: EventName = "وفات حضرت زینب"; break;
                        case 25: EventName = "شهادت حضرت امام موسی کاظم ع"; break;
                        case 27: EventName = "مبعث رسول اکرم ص -- تعطیل"; break;
                    }
                    break;
                case 8:
                    switch (day)
                    {
                        case 3: EventName = "ولادت حضرت امام حسین ع و روز پاسدار"; break;
                        case 4: EventName = "ولادت حضرت ابوالفضل العباس و روز جانباز"; break;
                        case 5: EventName = "ولادت حضرت امام زین العابدین ع"; break;
                        case 11: EventName = "ولادت حضرت علی اکبر ع و روز جوان"; break;
                        case 15: EventName = "ولادت حضرت قائم عج روز جهانی مستضعفان -- تعطیل"; break;
                    }
                    break;
                case 9:
                    switch (day)
                    {
                        case 10: EventName = "وفات حضرت خدیجه س"; break;
                        case 15: EventName = "ولادت حضرت امام حسن مجتبی علیه السلام و روز اکرام"; break;
                        case 18: EventName = "شب قدر"; break;
                        case 19: EventName = " ضربت خوردن حضرت علی ع روز گفت و گوی تمدنها"; break;
                        case 20: EventName = "شب قدر"; break;
                        case 21: EventName = "شهادت حضرت علی علیه السلام -- تعطیل"; break;
                        case 22: EventName = "شب قدر"; break;
                    }
                    break;
                case 10:
                    switch (day)
                    {
                        case 1: EventName = "عید سعید فطر -- تعطیل"; break;
                        case 3: EventName = "سالروز شهادت حضرت سلطان علی بن امام محمد باقر"; break;
                        case 25: EventName = "شهادت امام جعفر صادق ع -- تعطیل"; break;
                    }
                    break;
                case 11:
                    switch (day)
                    {
                        case 1: EventName = "ولادت حضرت معصومه س"; break;
                        case 11: EventName = "ولادت حضرت امام رضا ع"; break;
                        case 29: EventName = "شهادت امام محمد تقی ع جواد الائمه"; break;
                    }
                    break;
                case 12:
                    switch (day)
                    {
                        case 1: EventName = "سالروز ازدواج حضرت علی ع و حضرت فاطمه س"; break;
                        case 7: EventName = "شهادت امام محمد باقر ع"; break;
                        case 9: EventName = "روز عرفه - روز نیایش"; break;
                        case 10: EventName = "عید سعید قربان -- تعطیل "; break;
                        case 15: EventName = "ولادت حضرت امام علی النقی الهادی ع"; break;
                        case 18: EventName = "روز غدیر خم "; break;
                        case 24: EventName = "روز مباهله پیامبر اسلام ص"; break;
                        case 25: EventName = " روز خانواده وتکریم بازنشستگان "; break;
                    }
                    break;

            }
            return EventName;
        }

        private string GetPersianEvent(int month, int day)
        {
            string EventName = "";
            switch (month)
            {
                case 1:
                    switch (day)
                    {
                        case 1: EventName = "سال نو بر شما مبارک باد"; break;
                        case 2: EventName = "هجوم ماموران ستم شاهی به مدرسه ی فیضیه ی قم"; break;
                        case 12: EventName = "روز جمهوری اسلامی ایران -- تعطیل"; break;
                        case 13: EventName = "روز طبیعت -- تعطیل"; break;
                        case 18: EventName = "روز سلامتی - روز جهانی بهداشت"; break;
                        case 19: EventName = "شهادت آیت اله سید محمد باقر صدر و خواهر ایشان بنت الهدی توسط رژیم بعث عراق"; break;
                        case 20: EventName = "روز ملی فناوری هسته ای"; break;
                        case 21: EventName = "شهادت امیر سپهبد علی صیاد شیرازی"; break;
                        case 25: EventName = "روز بزرگداشت عطار نیشابوری"; break;
                        case 29: EventName = "روز ارتش جمهوری اسلامی ایران"; break;
                    }
                    break;
                case 2:
                    switch (day)
                    {
                        case 1: EventName = "روز بزرگداشت سعدی"; break;
                        case 2: EventName = "تاسیس سپاه پاسداران انتقلاب اسلامی - سالروز اعلام انقلاب فرهنگی - روز زمین پاک"; break;
                        case 3: EventName = "روز بزرگداشت شیخ بهایی - روز ملی کار آفرینی"; break;
                        case 5: EventName = "شکست حمله نظامی آمریکا به ایران در طبس"; break;
                        case 9: EventName = "روز شوراها"; break;
                        case 10: EventName = " روز ملی خلیج فارس - آغاز عملیات بیت المقدس"; break;
                        case 12: EventName = "شهادت استاد مرتضی مطهری - روز معلم - روز جهانی کار و کارگر"; break;
                        case 15: EventName = "روز بزرگداشت شیخ صدوق"; break;
                        case 17: EventName = "روز اسناد ملی"; break;
                        case 19: EventName = "روز جهانی صلیب سرخ و حلال احمر"; break;
                        case 24: EventName = "لغو امتیاز تنباکو به فتوای آیت الله میرزا حسن شیرازی"; break;
                        case 25: EventName = "روز بزرگداشت فردوسی"; break;
                        case 27: EventName = "روز جهانی ارتباطات و روابط عمومی"; break;
                        case 28: EventName = "روز بزرگداشت حکیم عمر خیام"; break;
                        case 29: EventName = "روز جهانی موزه و میراث فرهنگی"; break;
                    }
                    break;
                case 3:
                    switch (day)
                    {
                        case 1: EventName = "روز بهره وری و بهینه سازی مصرف - روز بزرگداشت ملا صدرا"; break;
                        case 3: EventName = "فتح خرم شهر در عملیات بیت امقدس و روز مقاومت ، ایثار و پیروزی"; break;
                        case 14: EventName = "رحلت حضرت امام خمینی -- تعطیل"; break;
                        case 15: EventName = "قیام خونین 15 خرداد -- تعطیل"; break;
                        case 16: EventName = "روز جهانی محیط زیست"; break;
                        case 20: EventName = "شهادت آیت الله سعیدی به دست ماموران ستم شاهی پهلوی"; break;
                        case 24: EventName = "روز جهانی صنایع دستی"; break;
                        case 25: EventName = "روز گل و گیاه"; break;
                        case 26: EventName = "شهادت سربازان دلیر اسلام،بخارایی،امانی،صفار هرندی و نیک نژاد"; break;
                        case 27: EventName = "روز جهاد کشاورزی -- تشکیل جهاد سازندگی به فرمان امام"; break;
                        case 28: EventName = "روز جهانی بیابان زدایی"; break;
                        case 29: EventName = "درگذشت دکتر علی شریعتی"; break;
                        case 30: EventName = "انفجار در حرم حضرت امام رضا به دست منافقین کور دل"; break;
                        case 31: EventName = "شهادت دکتر مصطفی چمران"; break;
                    }
                    break;
                case 4:
                    switch (day)
                    {
                        case 1: EventName = "روز تبلیغ و اطلاع رسانی دینی - روز اصناف"; break;
                        case 6: EventName = "روز جهانی مبارزه با مواد مخدر"; break;
                        case 7: EventName = "شهادت آیت الله دکتر بهشتی و 72 تن از یاران امام - روز قوه قضاییه"; break;
                        case 8: EventName = "روز مبارزه با صلاح های میکروبی و شیمیایی"; break;
                        case 10: EventName = "روز صنعت و معدن"; break;
                        case 11: EventName = "شهادت آیت الله صدوقی چهارمین شهید محراب به دست به دست منافقین"; break;
                        case 12: EventName = "سقوط هواپیمای مسافر بری جمهوری اسلامی ایران توسط آمریکا"; break;
                        case 14: EventName = "روز قلم"; break;
                        case 16: EventName = "روز مالیات"; break;
                        case 25: EventName = "روز بهزیستی و تامین اجتماعی"; break;
                        case 27: EventName = "اعلام پذیرش قطعنامه شورای امنیت از سوی ایران"; break;

                    }
                    break;
                case 5:
                    switch (day)
                    {
                        case 5: EventName = "سالروز عملیات افتخار آفرین مرصاد"; break;
                        case 6: EventName = "روز ترویج آموزش های فنی و حرفه ای"; break;
                        case 8: EventName = "روز بزرگداشت شیخ شهاب الدین سهروردی شیخ اشراق"; break;
                        case 9: EventName = "روز اهدای خون"; break;
                        case 14: EventName = "صدور فرمان مشروطیت"; break;
                        case 16: EventName = "تشکیل جهاد دانشگاهی "; break;
                        case 17: EventName = "روز خبرنگار"; break;
                        case 26: EventName = "آغاز بازگشت آزادگان به میهن اسلامی"; break;
                        case 28: EventName = "کودتای آمریکا برای بازگرداندن شاه"; break;
                        case 30: EventName = "روز بزرگداشت علامه مجلسی"; break;
                        case 31: EventName = "روز جهانی مسجد"; break;
                    }
                    break;
                case 6:
                    switch (day)
                    {
                        case 1: EventName = "روز پزشک - روز بزرگداشت ابوعلی سینا"; break;
                        case 2: EventName = "آغاز هفته دولت"; break;
                        case 4: EventName = "روز کارمند"; break;
                        case 5: EventName = "روز دارو سازی - روز بزرگداشت محمد بن زکریای رازی"; break;
                        case 8: EventName = "روز مبارزه با تروریسم - انفجار دفتر نخست وزیری"; break;
                        case 10: EventName = "روز بانکداری اسلامی - سالروز تصویب قانون عملیات بانکی بدون ربا"; break;
                        case 11: EventName = "روز صنعت چاپ"; break;
                        case 13: EventName = "روز تعاون - روز بزرگداش ابو ریحان بیرونی"; break;
                        case 14: EventName = "شهادت آیت الله قدوسی و سرتیپ وحید دستجردی"; break;
                        case 17: EventName = "قیام 17 شهریور و کشتار جمعی از مردم به دست ماموران پهلوی"; break;
                        case 19: EventName = "وفات آیت الله سید محمد طالقانی اولین امام جمعه تهران"; break;
                        case 20: EventName = "شهادت دوین شهید محراب آیت الله مدنی به دست منافقین"; break;
                        case 21: EventName = "روز سینما"; break;
                        case 27: EventName = "روز شعر و ادب فارسی - وز بزرگداشت استاد سید محمد حسین شهریار"; break;
                        case 31: EventName = "آغاز جنگ تحمیلی - آغاز هفته ی دفاع مقدس"; break;
                    }
                    break;
                case 7:
                    switch (day)
                    {


                        case 5: EventName = "شکست حصر آبادان در عملیات ثامن الائمه"; break;
                        case 6: EventName = "روز جهانی جهانگردی"; break;
                        case 7: EventName = "روز آتشنشانی و ایمنی - شهادت سرداران اسلام"; break;
                        case 8: EventName = "روز بزرگداشت مولوی"; break;
                        case 9: EventName = "روز جهانی ناشنوایان و روز همبستگی کودکان و نوجوانان فلسطینی"; break;
                        case 13: EventName = "هجرت حضرت امام خمینی ره از عراق به پاریس - روز نیروی انتظامی"; break;
                        case 14: EventName = "روز دامپزشکی"; break;
                        case 17: EventName = "روز جهانی کودک "; break;
                        case 20: EventName = "روز بزگداشت حافظ - روز اسکان معلولان و سالمندان - روز ملی کاهش بلایای طبیعی"; break;
                        case 23: EventName = "شهادت پنجمین شهید معراب آیت الله اشرفی اصفهانی - روز جهانی استاندارد"; break;
                        case 24: EventName = "روز پیوند اولیا و مربیان - روز جهانی نابینایان عصای سفید"; break;
                        case 26: EventName = "روز تربیت بدنی و ورزش"; break;
                        case 29: EventName = "روز صادرات"; break;
                    }
                    break;
                case 8:
                    switch (day)
                    {
                        case 1: EventName = "روز آمار  برنامه ریزی"; break;
                        case 4: EventName = "اعتراض افشاگری حضرت امام خمینی ره علیه پذیرش کاپیتولاسیون"; break;
                        case 8: EventName = "شهادت محمد حسین فهمیده - روز نوجوان - روز بسیج دانش آموزی"; break;
                        case 10: EventName = "شهادت آیت الله قاضی طباطبایی اولین شهید محراب"; break;
                        case 13: EventName = "روز ملی مبارزه با استکبار جهانی - روز دانش آموز - تسخیر لانه جاسوسی آمریکا به دست دانشجویان پیرو خط امام"; break;
                        case 14: EventName = "روز فرهنگ عمومی"; break;
                        case 18: EventName = "روز ملی کیفیت"; break;
                        case 24: EventName = "روز کتابخوانی - روز بزرگداشت علامه سید محمد حسین طباطبایی"; break;
                    }
                    break;
                case 9:
                    switch (day)
                    {
                        case 5: EventName = "روز بسیج مستضعفان - تشکیل بسیج مستضعفین به فرمان حضرت امام خمینی ره"; break;
                        case 7: EventName = "روز نیروی دریایی"; break;
                        case 9: EventName = "روز بزرگداشت شیخ مفید"; break;
                        case 10: EventName = "شهادت آیت سید حسن مدرس و روز مجلس"; break;
                        case 12: EventName = "تصویب قانون اساسی جمهوری اسلامی ایران"; break;
                        case 13: EventName = "روز جهانی معلولان و روز بیمه"; break;
                        case 15: EventName = "شهادت مظلومانه زائران خانه ی خدا به دستور آمریکا"; break;
                        case 16: EventName = "روز داشجو"; break;
                        case 18: EventName = "معرفی عراق بعنوان مسئول و آغاز جنگ از سوی سازمان ملل"; break;
                        case 19: EventName = "تشکیل شورای انقلاب فرهنگی به فرمان حضرت امام خمینی ره "; break;
                        case 20: EventName = "شهادت آیت الله دست غیب سومین شهید محراب به دست منافقین"; break;
                        case 25: EventName = "روز پژوهش"; break;
                        case 26: EventName = "روز حمل ونقل"; break;
                        case 27: EventName = "شهادت آیت الله دکتر محمد مفتح - روز وحدت حوزه و دانشگاه"; break;
                    }
                    break;
                case 10:
                    switch (day)
                    {
                        case 5: EventName = "روز ملی ایمنی در برابر زلزله"; break;
                        case 7: EventName = "سالروز تشکیل نهضت سوادآموزی به فرمان حضرت امام خمینی ره - شهادت آیت الله حسین غفاری به دست پهلوی"; break;
                        case 19: EventName = "قیام خونین مردم قم - روز تجلیل از اسرا و مفقودان"; break;
                        case 20: EventName = "شهادت میرزا تقی خان امیر کبیر"; break;
                        case 22: EventName = "تشکیل شورای انقلاب به فرمان حضرت امام خمینی ره"; break;
                        case 26: EventName = "فرار شاه معدوم"; break;
                        case 27: EventName = "شهادت نواب صفوی ، طهماسبی ، برادران واحدی و ذوالقدر از فداییان اسلام"; break;
                    }
                    break;
                case 11:
                    switch (day)
                    {
                        case 6: EventName = "سالروز حماسه مردم آمل"; break;
                        case 12: EventName = "بازگشت حضرت امام خمینی ره به ایران و آغاز دهه ی مبارک فجر"; break;
                        case 14: EventName = " پرتاب موفقيت آميز ماهواره اميد به فضا و بازتاب آن در رسانه هاي جهان "; break;
                        case 19: EventName = "روز نیروی هوایی"; break;
                        case 22: EventName = "پیروزی انقلاب و سقوط شاهنشاهی -- تعطیل"; break;
                        case 29: EventName = "قیام مردم تبریز چهلمین روز شهادت شهدای قم"; break;
                    }
                    break;
                case 12:
                    switch (day)
                    {
                        case 5: EventName = "روز بزرگداشت خواجه نصیرالدین طوسی - روز مهندسی - روز وقف"; break;
                        case 8: EventName = "روز امور تربیتی و تربیت اسلامی"; break;
                        case 9: EventName = "روز ملی حمایت از حقوق مصرف کنندگاه"; break;
                        case 14: EventName = "روز احسان و نیکوکاری"; break;
                        case 15: EventName = "روز درختکاری"; break;
                        case 22: EventName = "روز بزرگداشت شهدا"; break;
                        case 25: EventName = "روز اخلاق و مهرورزی -  بمباران شیمیایی حلبچه توسط عراق"; break;
                        case 29: EventName = "روز ملی شدن صنعت نفت ایران -- تعطیل"; break;
                    }
                    break;
            }
            return EventName;
        }

        public static string ToPersianDigit(string value)
        {
            var dic = new Dictionary<char, char>
                          {
                              {'0','٠'},
                              {'1','١'},
                              {'2','٢'},
                              {'3','٣'},
                              {'4','٤'},
                              {'5','٥'},
                              {'6','٦'},
                              {'7','٧'},
                              {'8','٨'},
                              {'9','٩'}
                          };

            return value.Aggregate(string.Empty, (current, chr) => current + (char.IsDigit(chr) ? dic[chr] : chr));
        }




        //private string ayyam()
        //{
            
        //    /////////////////////////////////////////////////////////////////////////////////////////////////////////
           
        //    if (mydate.Month == 1 && mydate.Day == 1)
        //        ayyam_name3 = ayyam_name + " - " + ayyam_name2 + " - " + "آغاز سال جدید میلادی";
        //    else if (mydate.Month == 12 && mydate.Day == 25)
        //        ayyam_name3 = ayyam_name + " - " + ayyam_name2 + " - " + "میلاد حضرت عیسی مسیح علیه السلام";
        //    //////////////////////////////////////////////////////////////////////////////////////////////////
        //    return ayyam_name3 = ayyam_name2 + " - " + ayyam_name; ;
        //}
    }
}
