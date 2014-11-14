using System;
using System.Collections.Generic;
using System.Text;

namespace BackupRestoreToolkit
{
    public static class Calendar
    {
        public static string getPersianDate(int day, string seprator)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTime = dateTime.AddDays(day);
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return string.Format("{0:0000}{1}{2:00}{3}{4:00}", pc.GetYear(dateTime), seprator,
                pc.GetMonth(dateTime), seprator, pc.GetDayOfMonth(dateTime));            
        }

        public static string getGregorianDate(int day, string seprator)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTime = dateTime.AddDays(day);
            return string.Format("{0:0000}{1}{2:00}{3}{4:00}", dateTime.Year, seprator, dateTime.Month, seprator, dateTime.Day);
        }

        public static string getPersianDate()
        {
            return getPersianDate(0,"/");
        }

        public static int DateDiffrence(DateTime BeginDate, DateTime EndDate)
        {
            TimeSpan timeSpan = EndDate.Subtract(BeginDate);
            return timeSpan.Days;
        }

        public static int PersianDateDiffrence(string BeginDate, string EndDate)
        {
            DateTime beginDate = Persia.Calendar.ConvertToGregorian(Convert.ToInt32(BeginDate.Substring(0, 4)),
                                                                    Convert.ToInt32(BeginDate.Substring(5, 2)),
                                                                    Convert.ToInt32(BeginDate.Substring(8,2)),
                                                                    Persia.DateType.Persian);
            DateTime endDate = Persia.Calendar.ConvertToGregorian(Convert.ToInt32(EndDate.Substring(0, 4)),
                                                                    Convert.ToInt32(EndDate.Substring(5, 2)),
                                                                    Convert.ToInt32(EndDate.Substring(8, 2)),
                                                                    Persia.DateType.Persian);
            
            TimeSpan timeSpan = endDate.Subtract(beginDate);
            return timeSpan.Days;
        }

        public static string getHourNow()
        {
            return string.Format("{0:00}:{1:00}", DateTime.Now.Hour, DateTime.Now.Minute);
        }

        public static string getPersianWeekDay()
        {
            return Persia.Calendar.ConvertToPersian(DateTime.Now).Weekday.ToString();
        }
    }
}
