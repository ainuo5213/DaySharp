using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HolidaySharp
{
    public enum SolarTerms
    {
        [SolarTermDescription("立春", 2)]
        LICHUN,
        [SolarTermDescription("雨水", 2)]
        YUSHUI,
        [SolarTermDescription("惊蛰", 3)]
        JINGZHE,
        [SolarTermDescription("春分", 3)]
        CHUNFEN,
        [SolarTermDescription("清明", 4)]
        QINGMING,
        [SolarTermDescription("谷雨", 4)]
        GUYU,
        [SolarTermDescription("立夏", 5)]
        LIXIA,
        [SolarTermDescription("小满", 5)]
        XIAOMAN,
        [SolarTermDescription("芒种", 6)]
        MANGZHONG,
        [SolarTermDescription("夏至", 6)]
        XIAZHI,
        [SolarTermDescription("小暑", 7)]
        XIAOSHU,
        [SolarTermDescription("大暑", 7)]
        DASHU,
        [SolarTermDescription("立秋", 8)]
        LIQIU,
        [SolarTermDescription("处暑", 8)]
        CHUSHU,
        [SolarTermDescription("白露", 9)]
        BAILU,
        [SolarTermDescription("秋分", 9)]
        QIUFEN,
        [SolarTermDescription("寒露", 10)]
        HANLU,
        [SolarTermDescription("霜降", 10)]
        SHUANGJIANG,
        [SolarTermDescription("立冬", 11)]
        LIDONG,
        [SolarTermDescription("小雪", 11)]
        XIAOXUE,
        [SolarTermDescription("大雪", 12)]
        DAXUE,
        [SolarTermDescription("冬至", 12)]
        DONGZHI,
        [SolarTermDescription("小寒", 1, true)]
        XIAOHAN,
        [SolarTermDescription("大寒", 1, true)]
        DAHAN
    }
}
