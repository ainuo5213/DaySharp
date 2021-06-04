using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySharp
{
    public abstract class Holiday
    {
        public string Name { get; set; }
        public DateTime? SolarTime { get; set; }
        public DateTime? LunarTime { get; set; }

        public override string ToString()
        {
            return $"节日名称：{this.Name}，节日阳历时间{this.SolarTime}，节日农历时间{this.LunarTime}";
        }
    }
}
