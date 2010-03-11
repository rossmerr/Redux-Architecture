using System;
using System.Globalization;

namespace ReduxArch.Util
{
    public static class DateTimeExtensions
    {
        public static string GetMonth(this DateTime current)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[current.Month - 1];
        }

        public static DateTime SetTime(this DateTime current, TimeSpan source)
        {
            return current.SetTime(source.Hours, source.Minutes, 0, 0);
        }

        public static DateTime SetTime(this DateTime current, DateTime source)
        {
            return current.SetTime(source.Hour, source.Minute, 0, 0);
        }

        public static DateTime SetTime(this DateTime current, int hour, int minute)
        {
            return current.SetTime(hour, minute, 0, 0);
        }

        public static DateTime SetTime(this DateTime current, int hour, int minute, int second)
        {
            return current.SetTime(hour, minute, second, 0);
        }

        public static DateTime SetTime(this DateTime current, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(current.Year, current.Month, current.Day, hour, minute, second, millisecond);
        }

        public static DateTime RoundToSeconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }

        public static DateTime Midnight(this System.DateTime entity)
        {
            return DateTime.Parse(entity.Day + " " + entity.Month + " " + entity.Year);          
        }

        public static double MinutesFromMidnight(this System.DateTime entity)
        {
            DateTime date = entity.Midnight();
            TimeSpan span = entity.Subtract(date);
            return span.TotalMinutes;
        }

        public static double MilliTimeStamp(this System.DateTime date)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = date.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }

        public static System.DateTime MillisecondsToDateTime(double milliseconds)
        {
            DateTime d1 = new System.DateTime(1970, 1, 1);
            return d1.AddMilliseconds(milliseconds);
        }
    }
}