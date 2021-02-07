namespace DotNetCenter.DateTime.Persian
{
    using System;
    using System.Globalization;
    /// <summary>
    /// Represents Persian Date-Time, typically expressed as a date and time of day in the persian calendar.
    /// </summary>
    public class PersianDateTime
    {

        public static string AM = "ق.ظ";
        public static string PM = "ب.ظ";

        private readonly static PersianCalendar _persianCalendar = new PersianCalendar();

        private readonly static string[] _monthNames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        private readonly static string[] _dayNames = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه" };

        /// <summary>
        /// Specifies the persian date and time mode to determining the PDateTime.Now.
        /// </summary>
        public static PersianDateTimeMode Mode = PersianDateTimeMode.UtcOffset;
        public static TimeSpan DaylightSavingTimeStart = TimeSpan.FromDays(1);
        public static TimeSpan DaylightSavingTimeEnd = TimeSpan.FromDays(185);
        public static TimeSpan DaylightSavingTime = TimeSpan.FromHours(1);
        public static TimeSpan OffsetFromUtc = new TimeSpan(3, 30, 0);

        private static TimeZoneInfo persianTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
        /// <summary>
        /// Get Persian Time-Zone Information
        /// </summary>
        /// <returns>Persian Time-Zone Information from current system</returns>
        public static TimeZoneInfo GetPersianTimeZoneInformation()
            => persianTimeZoneInfo;
        /// <summary>
        /// Subtracts a specified date and time from another specified date and time and returns a time interval.
        /// </summary>
        /// <param name="persianDateTime1">The date and time value to subtract from (the minuend).</param>
        /// <param name="persianDateTime2">The date and time value to subtract (the subtrahend).</param>
        /// <returns>The time interval between d1 and d2; that is, d1 minus d2.</returns>
        public static TimeSpan operator -(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
            => persianDateTime1.ToDateTime() - persianDateTime2.ToDateTime();

        /// <summary>
        /// Determines whether one specified PDateTime is greater than another specified PDateTime.
        /// </summary>
        /// <param name="persianDateTime1">The first object to compare.</param>
        /// <param name="persianDateTime2">The second object to compare.</param>
        /// <returns>true if d1 is greater than d2; otherwise, false.</returns>
        public static bool operator >(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
            => persianDateTime1.ToDateTime() > persianDateTime2.ToDateTime();

        /// <summary>
        /// Determines whether one specified PDateTime is greater than or equal to another specified PDateTime.
        /// </summary>
        /// <param name="persianDateTime1">The first object to compare.</param>
        /// <param name="persianDateTime2">The second object to compare.</param>
        /// <returns>true if d1 is greater than or equal to d2; otherwise, false.</returns>
        public static bool operator >=(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
            => persianDateTime1.ToDateTime() >= persianDateTime2.ToDateTime();

        /// <summary>
        /// Determines whether one specified PDateTime is less than or equal to another specified PDateTime.
        /// </summary>
        /// <param name="persianDateTime1">The first object to compare.</param>
        /// <param name="persianDateTime2">The second object to compare.</param>
        /// <returns>true if d1 is less than or equal to d2; otherwise, false.</returns>
        public static bool operator <=(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
            => persianDateTime1.ToDateTime() <= persianDateTime2.ToDateTime();

        /// <summary>
        /// Subtracts a specified time interval from a specified date and time and returns a new date and time.
        /// </summary>
        /// <param name="value">The date and time value to subtract from.</param>
        /// <param name="interval">The time interval to subtract.</param>
        /// <returns>An object whose value is the value of d minus the value of t.</returns>
        public static PersianDateTime operator -(PersianDateTime value, TimeSpan interval) => new PersianDateTime(value.ToDateTime() - interval);

        /// <summary>
        /// Adds a specified time interval to a specified date and time, yielding a new date and time.
        /// </summary>
        /// <param name="value">The date and time value to add.</param>
        /// <param name="interval">The time interval to add.</param>
        /// <returns>An object that is the sum of the values of d and t.</returns>
        public static PersianDateTime operator +(PersianDateTime value, TimeSpan interval) => new PersianDateTime(value.ToDateTime() + interval);

        /// <summary>
        /// Determines whether one specified PDateTime is less than another specified PDateTime.
        /// </summary>
        /// <param name="persianDateTime1">The first object to compare.</param>
        /// <param name="persianDateTime2">The second object to compare.</param>
        /// <returns>true if d1 is less than d2; otherwise, false.</returns>
        public static bool operator <(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
            => persianDateTime1.ToDateTime() < persianDateTime2.ToDateTime();

        /// <summary>
        /// Determines whether two specified instances of PDateTime are equal.
        /// </summary>
        /// <param name="persianDateTime1">The first object to compare.</param>
        /// <param name="persianDateTime2">The second object to compare.</param>
        /// <returns>true if d1 and d2 represent the same date and time; otherwise, false.</returns>
        public static bool operator ==(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
        {
            if (persianDateTime1 is null) return persianDateTime2 is null;
            if (persianDateTime2 is null) return false;

            return persianDateTime1.ToDateTime() == persianDateTime2.ToDateTime();
        }

        /// <summary>
        /// Determines whether two specified instances of PDateTime are not equal.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 and d2 do not represent the same date and time; otherwise, false.</returns>
        public static bool operator !=(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => !(persianDateTime1 == persianDateTime2);

        /// <summary>
        /// Returns the name of the specified month.
        /// </summary>
        /// <param name="month">An integer that represents the month, and ranges from 1 through 12.</param>
        /// <returns>The name of the specified month.</returns>
        public static string GetMonthName(int month) => _monthNames[month + 1];

        /// <summary>
        /// Returns the name of the specified day.
        /// </summary>
        /// <param name="day">An integer that represents the day, and ranges from 0 through 6.</param>
        /// <returns>The name of the specified day.</returns>
        public static string GetDayName(int day) => _dayNames[day];

        /// <summary>
        /// Determines whether the specified year is a leap year. The number of days is 366 in a leap year.
        /// </summary>
        /// <param name="year">An integer from 1 through 9378 that represents the year.</param>
        /// <returns>true if the specified year is a leap year; otherwise, false.</returns>
        public static bool IsLeapYear(int year) => _persianCalendar.IsLeapYear(year);

        /// <summary>
        /// Returns the number of days in the specified year.
        /// </summary>
        /// <param name="year">An integer from 1 through 9378 that represents the year.</param>
        /// <returns>The number of days in the specified year. The number of days is 365 in a common year or 366 in a leap year.</returns>
        public static int GetDaysInYear(int year)  => _persianCalendar.GetDaysInYear(year);

        /// <summary>
        /// Returns the number of days in the specified month of the specified year.
        /// </summary>
        /// <param name="year">An integer from 1 through 9378 that represents the year.</param>
        /// <param name="month">An integer that represents the month, and ranges from 1 through 12.</param>
        /// <returns>The number of days in the specified month of the specified year.</returns>
        public static int GetDaysInMonth(int year, int month) => _persianCalendar.GetDaysInMonth(year, month);

        /// <summary>
        /// Get Persian Date-Time Now depends on 
        /// </summary>
        public static PersianDateTime Now
        {
            get {
                switch (Mode)
                {
                    case PersianDateTimeMode.System:
                        return new PersianDateTime(DateTime.Now);

                    case PersianDateTimeMode.PersianTimeZoneInfo:
                        return new PersianDateTime(TimeZoneInfo.ConvertTime(DateTime.Now, PersianTimeZoneInfo));

                    case PersianDateTimeMode.UtcOffset:
                        var now = new PersianDateTime(DateTime.UtcNow.Add(OffsetFromUtc));
                        return now.IsInDaylightSavingTime ? now.Add(DaylightSavingTime) : now;

                    default:
                        throw new NotSupportedException(Mode.ToString());
                }
            }
        }

        /// <summary>
        /// Converts the specified string representation of a date to its PDateTime equivalent.
        /// </summary>
        /// <param name="persianDate">A string containing a date to convert.</param>
        public static PersianDateTime Parse(string persianDate) => Parse(persianDate, "0");

        /// <summary>
        /// Converts the specified string representation of a date and time to its PDateTime equivalent.
        /// </summary>
        /// <param name="persianDate">A string containing a date to convert.</param>
        /// <param name="time">A string containing a time to convert.</param>
        public static PersianDateTime Parse(string persianDate, string time)
            => new PersianDateTime(int.Parse(persianDate.Replace("/", "")), int.Parse(time.Replace(":", "")));

        private readonly DateTime _dateTime;

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        public int Year => _persianCalendar.GetYear(_dateTime);

        /// <summary>
        /// Gets the month component of the date represented by this instance.
        /// </summary>
        public int Month => _persianCalendar.GetMonth(_dateTime);

        /// <summary>
        /// Gets the day of the month represented by this instance.
        /// </summary>
        public int Day => _persianCalendar.GetDayOfMonth(_dateTime);

        /// <summary>
        /// Gets the hour component of the date represented by this instance.
        /// </summary>
        public int Hour => _dateTime.Hour;

        /// <summary>
        /// Gets the minute component of the date represented by this instance.
        /// </summary>
        public int Minute => _dateTime.Minute;

        /// <summary>
        /// Gets the seconds component of the date represented by this instance.
        /// </summary>
        public int Second => _dateTime.Second;

        /// <summary>
        /// Gets the milliseconds component of the date represented by this instance.
        /// </summary>
        public int Millisecond => _dateTime.Millisecond;

        /// <summary>
        /// Gets the number of ticks that represent the date and time of this instance.
        /// </summary>
        public long Ticks => _dateTime.Ticks;

        private bool IsInDaylightSavingTime => TimeOfYear > DaylightSavingTimeStart && TimeOfYear < DaylightSavingTimeEnd;

        /// <summary>
        /// Gets the time of day for this instance.
        /// </summary>
        public TimeSpan TimeOfDay => _dateTime.TimeOfDay;

        /// <summary>
        /// Gets the time of year for this instance.
        /// </summary>
        public TimeSpan TimeOfYear => this - FirstDayOfYear;

        /// <summary>
        /// Gets the time of month for this instance.
        /// </summary>
        public TimeSpan TimeOfMonth => this - FirstDayOfMonth;

        /// <summary>
        /// Gets the time of week for this instance.
        /// </summary>
        public TimeSpan TimeOfWeek => this - FirstDayOfWeek;

        /// <summary>
        /// Initializes a new instance of the PDateTime class to a specified dateTime.
        /// </summary>
        /// <param name="dateTime">A date and time in the Gregorian calendar.</param>
        public PersianDateTime(DateTime dateTime) => _dateTime = dateTime;


        /// <summary>
        /// Initializes a new instance of the PDateTime class to the specified persian date.
        /// </summary>
        /// <param name="persianDate">The persian date</param>
        public PersianDateTime(int persianDate) : this(persianDate, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the PDateTime class to the specified persian date and time.
        /// </summary>
        /// <param name="persianDate">The persian date.</param>
        /// <param name="time">The time.</param>
        public PersianDateTime(int persianDate, short time) 
            : this(persianDate, time * 100) 
        { }

        /// <summary>
        /// Initializes a new instance of the PDateTime class to the specified persian date and time.
        /// </summary>
        /// <param name="persianDate">The persian date.</param>
        /// <param name="time">The time.</param>
        public PersianDateTime(int persianDate, int time)
        {
            var year = persianDate / 10000;
            var month = persianDate / 100 % 100;
            var day = persianDate % 100;
            var hour = time / 10000;
            var minute = time / 100 % 100;
            var second = time % 100;

            _dateTime = _persianCalendar.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        /// <summary>
        /// Initializes a new instance of the PDateTime class to the specified year, month, and day.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        public PersianDateTime(int year, int month, int day) 
            : this(year, month, day, 0, 0, 0) { }

        /// <summary>
        /// Initializes a new instance of the PDateTime class to the specified year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        public PersianDateTime(int year, int month, int day, int hour, int minute, int second)
            => _dateTime = _persianCalendar.ToDateTime(year, month, day, hour, minute, second, 0);

        /// <summary>
        /// Determines whether the year represented by this instance is a leap year. The number of days is 366 in a leap year.
        /// </summary>
        /// <returns>true if the year represented by this instance is a leap year; otherwise, false.</returns>
        public bool IsLeapYear() => _persianCalendar.IsLeapYear(Year);

        /// <summary>
        /// Returns the number of days in the year represented by this instance.
        /// </summary>
        public int DaysInYear => _persianCalendar.GetDaysInYear(Year);

        /// <summary>
        /// Returns the number of days in the month represented by this instance.
        /// </summary>
        public int DaysInMonth => _persianCalendar.GetDaysInMonth(Year, Month);

        /// <summary>
        /// Returns the week of the year that includes the date represented by this instance.
        /// </summary>
        /// <param name="rule">An enumeration value that defines a calendar week.</param>
        /// <returns>A positive integer that represents the week of the year that includes the date represented by this instance.</returns>
        public int GetWeekOfYear(CalendarWeekRule rule) => _persianCalendar.GetWeekOfYear(_dateTime, rule, System.DayOfWeek.Saturday);

        /// <summary>
        /// Gets the day of the year represented by this instance.
        /// </summary>
        public int DayOfYear => _persianCalendar.GetDayOfYear(_dateTime);

        /// <summary>
        /// Gets the day of the week represented by this instance.
        /// </summary>
        public int DayOfWeek => ((int)_dateTime.DayOfWeek + 1) % 7;

        /// <summary>
        /// Gets the name of the day of the week represented by this instance.
        /// </summary>
        public string DayName => _dayNames[DayOfWeek];

        /// <summary>
        /// Gets the name of the month represented by this instance.
        /// </summary>
        public string MonthName => _monthNames[Month - 1];

        /// <summary>
        /// Gets the date component of this instance.
        /// </summary>
        public PersianDateTime Date => new PersianDateTime(_dateTime.Date);

        /// <summary>
        /// Gets the first day of the year represented by this instance.
        /// </summary>
        public PersianDateTime FirstDayOfYear => AddDays(-DayOfYear + 1).Date;

        /// <summary>
        /// Gets the last day of the year represented by this instance.
        /// </summary>
        public PersianDateTime LastDayOfYear => AddDays(DaysInYear - DayOfYear).Date;

        /// <summary>
        /// Gets the first day of the month represented by this instance.
        /// </summary>
        public PersianDateTime FirstDayOfMonth => AddDays(-Day + 1).Date;

        /// <summary>
        /// Gets the last day of the month represented by this instance.
        /// </summary>
        public PersianDateTime LastDayOfMont => AddDays(DaysInMonth - Day).Date;

        /// <summary>
        /// Gets the first day of the week represented by this instance.
        /// </summary>
        public PersianDateTime FirstDayOfWeek => AddDays(-DayOfWeek).Date;

        /// <summary>
        /// Gets the last day of the week represented by this instance.
        /// </summary>
        public PersianDateTime LastDayOfWeek => AddDays(6 - DayOfWeek).Date;

        public static TimeZoneInfo PersianTimeZoneInfo { get => persianTimeZoneInfo; set => persianTimeZoneInfo = value; }

        /// <summary>
        /// Returns a new PDateTime that adds the specified number of seconds to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of seconds represented by value.</returns>
        public PersianDateTime AddSeconds(double value) 
            => new PersianDateTime(_dateTime.AddSeconds(value));

        /// <summary>
        /// Returns a new PDateTime that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of minutes represented by value.</returns>
        public PersianDateTime AddMinutes(double value) 
            => new PersianDateTime(_dateTime.AddMinutes(value));

        /// <summary>
        /// Returns a new PDateTime that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of hours represented by value.</returns>
        public PersianDateTime AddHours(double value) 
            => new PersianDateTime(_dateTime.AddHours(value));

        /// <summary>
        /// Returns a new PDateTime that adds the specified number of years to the value of this instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of years represented by value.</returns>
        public PersianDateTime AddYears(int value)
            => new PersianDateTime(Year + value, Month, Day).Add(TimeOfDay);

        /// <summary>
        /// Returns a new PDateTime that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="value">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        public PersianDateTime AddMonths(int value)
        {
            var months = Month + value;

            var newYear = GetNewYear(months);

            var newMonth = GetNewMonth(months);

            var daysInNewMonth = PersianDateTime.GetDaysInMonth(newYear, newMonth);

            var newDay = daysInNewMonth < Day ? daysInNewMonth : Day;

            return new PersianDateTime(newYear, newMonth, newDay).Add(TimeOfDay);
        }

        private static int GetNewMonth(int months) => months > 0 ? ((months - 1) % 12) + 1 : (months % 12) + 12;

        private int GetNewYear(int months) => Year + (months > 0 ? (months - 1) / 12 : (months / 12) - 1);

        /// <summary>
        /// Returns a new PDateTime that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.</returns>
        public PersianDateTime AddDays(double value)
            => new PersianDateTime(_dateTime.AddDays(value));

        /// <summary>
        /// Returns a new PDateTime that adds the value of the specified System.TimeSpan to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by value.</returns>
        public PersianDateTime Add(TimeSpan value) 
            => new PersianDateTime(_dateTime.Add(value));

        /// <summary>
        /// Returns a System.DateTime object that is set to the date and time represented by this instance.
        /// </summary>
        /// <returns>A System.DateTime object that is set to the date and time represented by this instance</returns>
        public DateTime ToDateTime() => _dateTime;

        /// <summary>
        /// Converts the date represented by this instance to an equivalent 32-bit signed integer.
        /// </summary>
        /// <returns>n 32-bit signed integer equivalent to the date represented by this instance.</returns>
        public int ToInt()
            => int.Parse($"{Year}{Month.ToString().PadLeft(2, '0')}{Day.ToString().PadLeft(2, '0')}");


        /// <summary>
        /// Converts the value of the current PDateTime object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the value of the current PDateTime object.</returns>
        public override string ToString() 
            => ToString(PersianDateTimeFormat.DateTime);

        /// <summary>
        /// Converts the value of the current PDateTime object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A custom date and time format string.</param>
        /// <returns>A string representation of value of the current PDateTime object as specified by format.</returns>
        public string ToString(string format)
        {
            var towDigitYear = (Year % 100).ToString();
            var month = Month.ToString();
            var day = Day.ToString();
            var fullHour = Hour.ToString();
            var hour = $"{CalculateHour()}";
            var minute = Minute.ToString();
            var second = Second.ToString();
            var dayPart = Hour >= 12 ? PM : AM;

            return format.Replace("yyyy", $"{Year}")
                         .Replace("yy", towDigitYear.PadLeft(2, '0'))
                         .Replace("y", towDigitYear)
                         .Replace("MMMM", MonthName)
                         .Replace("MM", month.PadLeft(2, '0'))
                         .Replace("M", month)
                         .Replace("dddd", DayName)
                         .Replace("ddd", $"{DayName[0]}")
                         .Replace("dd", day.PadLeft(2, '0'))
                         .Replace("d", day)
                         .Replace("HH", fullHour.PadLeft(2, '0'))
                         .Replace("H", $"{fullHour}")
                         .Replace("hh", hour.PadLeft(2, '0'))
                         .Replace("h", $"{hour}")
                         .Replace("mm", minute.PadLeft(2, '0'))
                         .Replace("m", $"{minute}")
                         .Replace("ss", second.PadLeft(2, '0'))
                         .Replace("s", second)
                         .Replace("tt", dayPart)
                         .Replace('t', dayPart[0]);
        }

        private int CalculateHour() 
            => Hour % 12 == 0 ? 12 : Hour % 12;

        /// <summary>
        /// Converts the value of the current PDateTime object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A persian date and time format string.</param>
        /// <returns>A string representation of value of the current PDateTime object as specified by format.</returns>
        public string ToString(PersianDateTimeFormat format)
            => format switch
            {

                PersianDateTimeFormat.Date => $" { Year }/{ Month.ToString().PadLeft(2, '0') }/{ Day.ToString().PadLeft(2, '0') }",

                PersianDateTimeFormat.DateTime => $"{ ToString(PersianDateTimeFormat.Date) } { TimeOfDay.ToHHMMSS() }",

                PersianDateTimeFormat.DateShortTime => $" { ToString(PersianDateTimeFormat.Date) } { TimeOfDay.ToHHMM() }",

                PersianDateTimeFormat.LongDate => $" { DayName } { Day } { MonthName }",

                PersianDateTimeFormat.LongDateFullTime => $" { DayName } { Day } { MonthName } ساعت { TimeOfDay.ToHHMMSS() }",

                PersianDateTimeFormat.LongDateLongTime => $" { DayName } { Day } { MonthName } ساعت { TimeOfDay.ToHHMM() }",

                PersianDateTimeFormat.ShortDateShortTime => $" { Day } { MonthName } { TimeOfDay.ToHHMM() }",

                PersianDateTimeFormat.FullDate => $" { DayName } { Day } { MonthName } { Year }",

                PersianDateTimeFormat.FullDateLongTime => $" { DayName } { Day } { MonthName } { Year } ساعت { TimeOfDay.ToHHMM() }",

                PersianDateTimeFormat.FullDateFullTime => $" { DayName } { Day } { MonthName } { Year } ساعت { TimeOfDay.ToHHMMSS() }",

                _ => throw new NotImplementedException(format.ToString()),
            };

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() 
            => _dateTime.GetHashCode();

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>true if value is an instance of PDateTime and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object value) 
            => Equals(value as PersianDateTime);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified PDateTime instance.
        /// </summary>
        /// <param name="value">A PDateTime instance to compare to this instance.</param>
        /// <returns>true if the value parameter equals the value of this instance; otherwise, false.</returns>
        public bool Equals(PersianDateTime value)
        {
            if (value is null) 
                return false;

            return _dateTime.Equals(value._dateTime);
        }
    }
}