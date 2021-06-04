using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySharp
{
    public class SolarHoliday : Holiday
    {
        public readonly static SolarHoliday NewYearDay = new SolarHoliday(Holidays.NewYearDay);
        public readonly static SolarHoliday ValentineDay = new SolarHoliday(Holidays.ValentineDay);
        public readonly static SolarHoliday CirisDay = new SolarHoliday(Holidays.CirisDay);
        public readonly static SolarHoliday WomenDay = new SolarHoliday(Holidays.WomenDay);
        public readonly static SolarHoliday FoolDay = new SolarHoliday(Holidays.FoolDay);
        public readonly static SolarHoliday LabourDay = new SolarHoliday(Holidays.LabourDay);
        public readonly static SolarHoliday MotherDay = new SolarHoliday(Holidays.MotherDay);
        public readonly static SolarHoliday ChildDay = new SolarHoliday(Holidays.ChildDay);
        public readonly static SolarHoliday FatherDay = new SolarHoliday(Holidays.FatherDay);
        public readonly static SolarHoliday TeacherDay = new SolarHoliday(Holidays.TeacherDay);
        public readonly static SolarHoliday NationalDay = new SolarHoliday(Holidays.NationalDay);
        public readonly static SolarHoliday ThanksGivingDay = new SolarHoliday(Holidays.ThanksGivingDay);
        public readonly static SolarHoliday ChristmasEveDay = new SolarHoliday(Holidays.ChristmasEveDay);
        public readonly static SolarHoliday ChristmasDay = new SolarHoliday(Holidays.ChristmasDay);
        public readonly static SolarHoliday ArmyDay = new SolarHoliday(Holidays.ArmyDay);
        public readonly static SolarHoliday PartyDay = new SolarHoliday(Holidays.PartyDay);

        public SolarHoliday(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            this.Name = name;
            if (Holidays.GetSolarHolidays().TryGetValue(name, out DateTime shortTime))
            {
                this.SolarTime = shortTime;
                this.LunarTime = Holidays.Solar2Lunar(shortTime);
            }
            else
            {
                this.SolarTime = null;
                this.LunarTime = null;
            }
        }

        public SolarHoliday(DateTime solarTime)
        {
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            this.Name = GetHolidayName(solarTime);
        }

        public SolarHoliday(string name, DateTime solarTime)
        {
            this.Name = name;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            this.SolarTime = solarTime;
        }

        public SolarHoliday(int month, int day)
        {
            var solarTime = new DateTime(DateTime.Now.Year, month, day);
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            this.Name = GetHolidayName(this.SolarTime);
        }

        public SolarHoliday(int year, int month, int day)
        {
            var solarTime = new DateTime(year, month, day);
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            this.Name = GetHolidayName(this.SolarTime);
        }

        public static IEnumerable<SolarHoliday> GetSolarMonthlyHolidays()
        {
            return GetSolarMonthlyHolidays(DateTime.Now.Year, DateTime.Now.Month);
        }

        public static IEnumerable<SolarHoliday> GetSolarMonthlyHolidays(int month)
        {
            if (ValidateMonth(month))
            {
                return GetSolarMonthlyHolidays(DateTime.Now.Year, month);
            }

            return default;
        }

        public static IEnumerable<SolarHoliday> GetSolarMonthlyHolidays(int year, int month)
        {
            if (ValidateMonth(month) && ValidateYear(year))
            {
                IEnumerable<SolarHoliday> lunarHolidays = new List<SolarHoliday>();
                Dictionary<string, DateTime> yearHolidays = Holidays.GetSolarHolidays(year);
                IEnumerable<SolarHoliday> monthHolidays = yearHolidays.Where(r => r.Value.Month == month).Select(r => new SolarHoliday(r.Key, r.Value));
                return monthHolidays;
            }

            return default;
        }

        public static IEnumerable<SolarHoliday> GetSolarMonthlyHolidays(DateTime solarTime)
        {
            if (ValidateTime(solarTime))
            {
                return GetSolarMonthlyHolidays(solarTime.Year, solarTime.Month);
            }

            return default;
        }

        public static IEnumerable<SolarHoliday> GetSolarYearlyHolidays()
        {
            return GetSolarYearlyHolidays(DateTime.Now);
        }

        public static IEnumerable<SolarHoliday> GetSolarYearlyHolidays(DateTime solarTime)
        {
            if (ValidateTime(solarTime))
            {
                return GetSolarYearlyHolidays(solarTime.Year);
            }

            return default;
        }

        public static IEnumerable<SolarHoliday> GetSolarYearlyHolidays(int year)
        {
            return Holidays.GetSolarHolidays(year).Select(r => new SolarHoliday(r.Key, r.Value));
        }

        public static SolarHoliday GetSolarHoliday()
        {
            return GetSolarHoliday(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public static SolarHoliday GetSolarHoliday(DateTime solarTime)
        {
            return GetSolarHoliday(solarTime.Year, solarTime.Month, solarTime.Day);
        }

        public static SolarHoliday GetSolarHoliday(int month, int day)
        {
            return GetSolarHoliday(DateTime.Now.Year, month, day);
        }

        public static SolarHoliday GetSolarHoliday(int year, int month, int day)
        {
            return Holidays.GetSolarHolidays(year).Where(r => r.Value.Day == day && r.Value.Month == month).Select(r => new SolarHoliday(r.Key, r.Value)).FirstOrDefault();
        }

        internal static string GetHolidayName(DateTime? time)
        {
            if (time == null) return null;

            foreach (var item in Holidays.GetSolarHolidays(time.Value.Year))
            {
                if (item.Value == time)
                {
                    return item.Key;
                }
            }

            return null;
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

        internal static bool IsValidYear(int year)
        {
            return year > DateTime.MinValue.Year && year < DateTime.MaxValue.Year;
        }

        internal static bool IsValidMonth(int month)
        {
            return month > 0 && month < 13;
        }

        internal static bool ValidateTime(DateTime time)
        {
            if (time < DateTime.MinValue || time > DateTime.MaxValue) throw new ArgumentOutOfRangeException($"year must be in {DateTime.MinValue.Year} and {DateTime.MaxValue.Year}");
            return true;
        }
    }
}
