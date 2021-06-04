using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HolidaySharp
{
    public class Holidays
    {
        public static readonly ChineseLunisolarCalendar chineseLunisolarCalendar = new ChineseLunisolarCalendar();
        public static Dictionary<string, DateTime> GetSolarHolidays()
        {
            return GetSolarHolidays(DateTime.Now.Year);
        }

        public static Dictionary<string, DateTime> GetSolarHolidays(int year)
        {
            Dictionary<string, DateTime> solarHolidays = new Dictionary<string, DateTime>()
            {
                {
                    NewYearDay, FormatSolarHoliday(year, 1,1)
                },
                {
                    ValentineDay, FormatSolarHoliday(year, 2,14)
                },
                {
                    CirisDay, FormatSolarHoliday(year, 3,7)
                },
                {
                    WomenDay, FormatSolarHoliday(year, 3,8)
                },
                {
                    FoolDay, FormatSolarHoliday(year, 4,1)
                },
                {
                    LabourDay, FormatSolarHoliday(year, 5,1)
                },
                {
                    MotherDay, GetMontherDay(year)
                },
                {
                    ChildDay, FormatSolarHoliday(year, 6,1)
                },
                {
                    FatherDay, GetFatherDay(year)
                },
                {
                    PartyDay, FormatSolarHoliday(year, 7,1)
                },
                {
                    ArmyDay, FormatSolarHoliday(year, 8,1)
                },
                {
                    TeacherDay, FormatSolarHoliday(year, 9,10)
                },
                {
                    NationalDay, FormatSolarHoliday(year, 10,1)
                },
                {
                    ThanksGivingDay, GetThanksGivingDay(year)
                },
                {
                    ChristmasEveDay, FormatSolarHoliday(year, 12,24)
                },
                {
                    ChristmasDay, FormatSolarHoliday(year, 12,25)
                },
            };

            return solarHolidays;
        }

        public static Dictionary<string, DateTime> GetLunarHolidays()
        {
            return GetLunarHolidays(DateTime.Now.Year);
        }

        public static Dictionary<string, DateTime> GetLunarHolidays(int year)
        {
            Dictionary<string, DateTime> lunarHolidays = new Dictionary<string, DateTime>()
            {
                { SpringFestival, FormatLunarHoliday(year, 1, 1) },
                { SecondDayAfterSpringFestival, FormatLunarHoliday(year, 1, 2) },
                { ThirdDayAfterSpringFestival, FormatLunarHoliday(year, 1, 3) },
                { ForthDayAfterSpringFestival, FormatLunarHoliday(year, 1, 4) },
                { FifthDayAfterSpringFestival, FormatLunarHoliday(year, 1, 5) },
                { LanternFestival, FormatLunarHoliday(year, 1, 15)},
                { DragonHeadRaisingFestival, FormatLunarHoliday(year, 2, 2) },
                { DragonBoatFestival, FormatLunarHoliday(year, 5, 5) },
                { QiqiaoFestival, FormatLunarHoliday(year, 7, 7) },
                { GhostFestival, FormatLunarHoliday(year, 7, 15) },
                { MidAutumnFestival, FormatLunarHoliday(year, 8, 15) },
                { DoubleNinthFestival, FormatLunarHoliday(year, 9, 9) },
                { SpiritFestival, FormatLunarHoliday(year, 10, 15) },
                { NorthernLittleNewYear, FormatLunarHoliday(year, 12, 23) },
                { SouthernLittleNewYear, FormatLunarHoliday(year, 12, 24) },
                { SprinFestivalEve, FormatLunarHoliday(year, 12, 30) },
            };

            return lunarHolidays;
        }



        // solar holiday
        public const string NewYearDay = "元旦节";
        public const string ValentineDay = "情人节";
        public const string CirisDay = "女生节";
        public const string WomenDay = "妇女节";
        public const string FoolDay = "愚人节";
        public const string LabourDay = "劳动节";
        public const string MotherDay = "母亲节";
        public const string ChildDay = "儿童节";
        public const string FatherDay = "父亲节";
        public const string TeacherDay = "教师节";
        public const string NationalDay = "国庆节";
        public const string ThanksGivingDay = "感恩节";
        public const string ChristmasEveDay = "平安夜";
        public const string ChristmasDay = "圣诞节";
        public const string ArmyDay = "建军节";
        public const string PartyDay = "建党节";

        // lunar holiday
        public const string NorthernLittleNewYear = "北方小年";
        public const string SouthernLittleNewYear = "南方小年";
        public const string SprinFestivalEve = "除夕";
        public const string SpringFestival = "春节";
        public const string SecondDayAfterSpringFestival = "初二";
        public const string ThirdDayAfterSpringFestival = "初三";
        public const string ForthDayAfterSpringFestival = "初四";
        public const string FifthDayAfterSpringFestival = "初五";
        public const string LanternFestival = "元宵节";
        public const string DragonHeadRaisingFestival = "龙头节";
        public const string DragonBoatFestival = "端午节";
        public const string QiqiaoFestival = "七夕节";
        public const string GhostFestival = "中元节";
        public const string MidAutumnFestival = "中秋节";
        public const string DoubleNinthFestival = "重阳节";
        public const string SpiritFestival = "下元节";


        private static DateTime FormatSolarHoliday(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

        private static DateTime FormatLunarHoliday(int year, int month, int day)
        {
            var maxDaysInMonth = chineseLunisolarCalendar.GetDaysInMonth(year, month, ChineseLunisolarCalendar.ChineseEra);
            if (day > maxDaysInMonth)
            {
                day = maxDaysInMonth;
            }

            return new DateTime(year, month, day);
        }

        private static DateTime GetThanksGivingDay(int year)
        {
            return GetSpecialDay(year, 11, 4, 4);
        }

        private static DateTime GetSpecialDay(int year, int month, int week, int dayofWeek)
        {
            var @time = new DateTime(year, month, 1);
            int nowDayOfWeek = (int)@time.DayOfWeek;
            int addDays = dayofWeek - nowDayOfWeek;
            @time = @time.AddDays(7 * (week - 1) + addDays);
            return @time;
        }

        private static DateTime GetMontherDay(int year)
        {
            return GetSpecialDay(year, 5, 2, 7);
        }

        private static DateTime GetFatherDay(int year)
        {
            return GetSpecialDay(year, 6, 3, 7);
        }

        public int GetLeapMonth(DateTime datetime)
        {
            return chineseLunisolarCalendar.GetLeapMonth(datetime.Year, 1);
        }

        public static DateTime Lunar2Solar(DateTime datetime)
        {
            int year = datetime.Year;
            int month = datetime.Month;
            int day = datetime.Day;

            int leapMonth = chineseLunisolarCalendar.GetLeapMonth(year);

            // 闰月会对应两个阳历日，分别是month和leapMonth
            if (leapMonth != 0 && month == leapMonth - 1)
            {
                month = leapMonth - 1;
            }

            if (leapMonth != 0 && month > leapMonth - 1)
            {
                month += 1; // 闰月之后月份要+1才对的上
            }

            var limitDays = chineseLunisolarCalendar.GetDaysInMonth(year, month);
            if (day > limitDays)
            {
                day = limitDays;
            }

            return chineseLunisolarCalendar.ToDateTime(year, month, day, 0, 0, 0, 0, ChineseLunisolarCalendar.ChineseEra);
        }

        public static DateTime Solar2Lunar(DateTime datetime)
        {
            int year = chineseLunisolarCalendar.GetYear(datetime);
            int month = chineseLunisolarCalendar.GetMonth(datetime);
            int leapMonth = chineseLunisolarCalendar.GetLeapMonth(year, ChineseLunisolarCalendar.ChineseEra);
            if (leapMonth != 0 && month > leapMonth - 1)
            {
                month = month - 1;
            }
            int day = chineseLunisolarCalendar.GetDayOfMonth(datetime);
            return new DateTime(year, month, day);
        }
    }
}
