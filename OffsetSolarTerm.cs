using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySharp
{
    /// <summary>
    /// 通过公式计算得到的节气偏差值
    /// </summary>
    internal class OffsetSolarTerm
    {
        internal SolarTerms SolarTerm { get; private set; }

        internal int Year { get; private set; }

        internal int Offset { get; private set; }

        internal static IEnumerable<OffsetSolarTerm> GetOffsetSolarTerms()
        {
            List<OffsetSolarTerm> offsetSolarTerms = new List<OffsetSolarTerm>();
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = -1, SolarTerm = SolarTerms.YUSHUI, Year = 2026 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.CHUNFEN, Year = 2084 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.LIXIA, Year = 1911 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.XIAOMAN, Year = 2008 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.MANGZHONG, Year = 1902 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.XIAZHI, Year = 1928 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.XIAOSHU, Year = 1925 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.XIAOSHU, Year = 2016 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.DASHU, Year = 1922 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.LIQIU, Year = 2002 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.BAILU, Year = 1927 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.QIUFEN, Year = 1942 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.SHUANGJIANG, Year = 2089 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.LIDONG, Year = 2089 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.XIAOXUE, Year = 1978 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.DAXUE, Year = 1954 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = -1, SolarTerm = SolarTerms.DONGZHI, Year = 1918 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = -1, SolarTerm = SolarTerms.DONGZHI, Year = 2021 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.XIAOHAN, Year = 1982 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = -1, SolarTerm = SolarTerms.XIAOHAN, Year = 2019 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.DAHAN, Year = 2000 });
            offsetSolarTerms.Add(new OffsetSolarTerm() { Offset = 1, SolarTerm = SolarTerms.DAHAN, Year = 2082 });
            return offsetSolarTerms;
        }
    }
}
