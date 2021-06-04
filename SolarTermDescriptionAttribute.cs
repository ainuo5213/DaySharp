using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySharp
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class SolarTermDescriptionAttribute : Attribute
    {
        internal string Name { get; set; }
        internal int Month { get; set; }
        public bool NextYear { get; set; }

        public SolarTermDescriptionAttribute(string name, int month)
        {
            this.Name = name;
            this.Month = month;
        }
        public SolarTermDescriptionAttribute(string name, int month, bool nextYear)
        {
            this.Name = name;
            this.Month = month;
            this.NextYear = nextYear;
        }
    }
}
