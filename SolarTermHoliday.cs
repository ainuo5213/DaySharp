using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySharp
{
    public class SolarTermHoliday : Holiday
    {

        public SolarTermHoliday()
        {
        }

        public SolarTermHoliday(string name)
        {
            this.Name = name;
            var solarTerm = GetSolarTerm(name);
            if (solarTerm != null)
            {
                int year = DateTime.Now.Year;
                DateTime? solarTime = SolarTerm.CalcSolarTermTime(year, solarTerm.Month, solarTerm.C, solarTerm.CurrentSolarTerms);
                this.SolarTime = solarTime;
                this.LunarTime = Holidays.Solar2Lunar(solarTime.Value);
            }
        }

        public SolarTermHoliday(DateTime solarTime)
        {
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            var solarTerm = GetSolarTerm(solarTime);
            if (solarTerm != null)
            {
                this.Name = solarTerm.SolarTermName;
            }
        }

        public SolarTermHoliday(string name, DateTime solarTime)
        {
            this.Name = name;
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
        }

        public SolarTermHoliday(int year, int month, int day)
        {
            DateTime solarTime = new DateTime(year, month, day);
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            var solarTerm = GetSolarTerm(solarTime);
            if (solarTerm != null)
            {
                this.Name = solarTerm.SolarTermName;
            }
        }

        public SolarTermHoliday(int month, int day)
        {
            DateTime solarTime = new DateTime(DateTime.Now.Year, month, day);
            this.SolarTime = solarTime;
            this.LunarTime = Holidays.Solar2Lunar(solarTime);
            var solarTerm = GetSolarTerm(solarTime);
            if (solarTerm != null)
            {
                this.Name = solarTerm.SolarTermName;
            }
        }

        public static IEnumerable<SolarTermHoliday> GetSolarTermHolidays()
        {
            int year = DateTime.Now.Year;
            return GetSolarTermHolidays(year);
        }

        public static IEnumerable<SolarTermHoliday> GetSolarTermHolidays(int year)
        {
            IEnumerable<SolarTerm> solarTerms = SolarTerm.GetSolarTerms(year);

            IEnumerable<SolarTermHoliday> solarTermHolidays = solarTerms.Select(r =>
            {
                var time = SolarTerm.CalcSolarTermTime(year, r.Month, r.C, r.CurrentSolarTerms);
                return new SolarTermHoliday(r.SolarTermName, time.Value);
            });

            return solarTermHolidays;
        }

        public static IEnumerable<SolarTermHoliday> GetSolarTermHolidays(int year, int month)
        {
            IEnumerable<SolarTerm> solarTerms = SolarTerm.GetSolarTerms(year).Where(r => r.Month == month);

            IEnumerable<SolarTermHoliday> solarTermHolidays = solarTerms.Select(r =>
            {
                var time = SolarTerm.CalcSolarTermTime(year, r.Month, r.C, r.CurrentSolarTerms);
                return new SolarTermHoliday(r.SolarTermName, time.Value);
            });

            return solarTermHolidays;
        }

        public static IEnumerable<SolarTermHoliday> GetSolarTermHolidays(DateTime currentTime)
        {
            return GetSolarTermHolidays(currentTime.Year);
        }

        private static SolarTerm GetSolarTerm(DateTime solarTime)
        {
            return SolarTerm.GetSolarTerm(solarTime);
        }

        private static SolarTerm GetSolarTerm(string name)
        {
            int year = DateTime.Now.Year;
            return GetSolarTerm(name, year);
        }

        private static SolarTerm GetSolarTerm(string name, int year)
        {
            return SolarTerm.GetSolarTerm(name, year);
        }
    }
}
