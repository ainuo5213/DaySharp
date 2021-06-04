using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySharp
{
    public class LunarHoliday : Holiday
    {
        public readonly static LunarHoliday NorthernLittleNewYear = new LunarHoliday(Holidays.NorthernLittleNewYear);
        public readonly static LunarHoliday SouthernLittleNewYear = new LunarHoliday(Holidays.SouthernLittleNewYear);
        public readonly static LunarHoliday SprinFestivalEve = new LunarHoliday(Holidays.SprinFestivalEve);
        public readonly static LunarHoliday SpringFestival = new LunarHoliday(Holidays.SpringFestival);
        public readonly static LunarHoliday SecondDayAfterSpringFestival = new LunarHoliday(Holidays.SecondDayAfterSpringFestival);
        public readonly static LunarHoliday ThirdDayAfterSpringFestival = new LunarHoliday(Holidays.ThirdDayAfterSpringFestival);
        public readonly static LunarHoliday ForthDayAfterSpringFestival = new LunarHoliday(Holidays.ForthDayAfterSpringFestival);
        public readonly static LunarHoliday FifthDayAfterSpringFestival = new LunarHoliday(Holidays.FifthDayAfterSpringFestival);
        public readonly static LunarHoliday LanternFestival = new LunarHoliday(Holidays.LanternFestival);
        public readonly static LunarHoliday DragonHeadRaisingFestival = new LunarHoliday(Holidays.DragonHeadRaisingFestival);
        public readonly static LunarHoliday DragonBoatFestival = new LunarHoliday(Holidays.DragonBoatFestival);
        public readonly static LunarHoliday QiqiaoFestival = new LunarHoliday(Holidays.QiqiaoFestival);
        public readonly static LunarHoliday GhostFestival = new LunarHoliday(Holidays.GhostFestival);
        public readonly static LunarHoliday MidAutumnFestival = new LunarHoliday(Holidays.MidAutumnFestival);
        public readonly static LunarHoliday DoubleNinthFestival = new LunarHoliday(Holidays.DoubleNinthFestival);
        public readonly static LunarHoliday SpiritFestival = new LunarHoliday(Holidays.SpiritFestival);
        public LunarHoliday() { }

        public LunarHoliday(string name)
        {
            this.Name = name;
            if (Holidays.GetLunarHolidays().TryGetValue(name, out DateTime dateTime))
            {
                this.LunarTime = Holidays.Solar2Lunar(dateTime);
                this.SolarTime = dateTime;
            }
            else
            {
                this.LunarTime = null;
                this.SolarTime = null;
            }
        }

        public LunarHoliday(DateTime lunarTime)
        {
            this.LunarTime = lunarTime;
            this.SolarTime = Holidays.Lunar2Solar(lunarTime);
            foreach (var item in Holidays.GetLunarHolidays())
            {
                if (item.Value == lunarTime)
                {
                    this.Name = item.Key;
                }
            }
        }

        public LunarHoliday(string name, DateTime lunarTime)
        {
            this.Name = name;
            this.LunarTime = lunarTime;
            this.SolarTime = Holidays.Lunar2Solar(lunarTime);
        }

        public LunarHoliday(int month, int day)
        {
            var lunarTime = new DateTime(DateTime.Now.Year, month, day);
            this.LunarTime = lunarTime;
            this.SolarTime = Holidays.Lunar2Solar(lunarTime);
            this.Name = GetHolidayName(this.LunarTime);
        }

        public static IEnumerable<Holiday> GetMonthlyHolidays(int month)
        {
            if (ValidateMonth(month))
            {
                int year = DateTime.Now.Year;
                return GetMonthlyHolidays(year, month);
            }
            return default;
        }

        public static IEnumerable<Holiday> GetMonthlyHolidays(int year, int month)
        {
            if (ValidateMonth(month) && ValidateYear(year))
            {
                IEnumerable<LunarHoliday> lunarHolidays = new List<LunarHoliday>();
                Dictionary<string, DateTime> yearHolidays = Holidays.GetLunarHolidays(year);
                IEnumerable<LunarHoliday> monthHolidays = yearHolidays.Where(r => r.Value.Month == month).Select(r => new LunarHoliday(r.Key, r.Value));

                return monthHolidays;
            }
            return default;
        }

        public static IEnumerable<Holiday> GetMonthlyHolidays(DateTime lunarTime)
        {
            if (ValidateTime(lunarTime))
            {
                return GetMonthlyHolidays(lunarTime.Year, lunarTime.Month);
            }

            return default;
        }

        public static IEnumerable<Holiday> GetYearlyHolidays()
        {
            return GetYearlyHolidays(Holidays.Solar2Lunar(DateTime.Now));
        }

        public static IEnumerable<Holiday> GetYearlyHolidays(DateTime lunarTime)
        {
            if (ValidateTime(lunarTime))
            {
                return GetYearlyHolidays(lunarTime.Year);
            }

            return default;
        }

        public static IEnumerable<Holiday> GetYearlyHolidays(int year)
        {
            return Holidays.GetLunarHolidays(year).Select(r => new LunarHoliday(r.Key, r.Value));
        }

        internal static string GetHolidayName(DateTime? time)
        {
            if (time == null) return null;

            foreach (var item in Holidays.GetLunarHolidays())
            {
                if (item.Value == time)
                {
                    return item.Key;
                }
            }

            return null;
        }

        internal static bool IsValidYear(int year)
        {
            int minYear = Holidays.chineseLunisolarCalendar.MinSupportedDateTime.Year;
            int maxYear = Holidays.chineseLunisolarCalendar.MaxSupportedDateTime.Year;
            return year > minYear && year < maxYear;
        }

        internal static bool ValidateYear(int year)
        {
            if (!IsValidYear(year)) throw new ArgumentOutOfRangeException($"year must be in {DateTime.MinValue.Year} and {DateTime.MaxValue.Year}");
            return true;
        }

        internal static bool ValidateMonth(int month)
        {
            if (!IsValidMonth(month)) throw new ArgumentOutOfRangeException("month must be in 1 and 12");
            return true;
        }

        internal static bool IsValidMonth(int month)
        {
            return month > 0 && month < 13;
        }

        internal static bool ValidateTime(DateTime time)
        {
            int year = time.Year;
            if (!IsValidYear(year)) throw new ArgumentOutOfRangeException($"year must be in {DateTime.MinValue.Year} and {DateTime.MaxValue.Year}");
            return true;
        }
    }
}
