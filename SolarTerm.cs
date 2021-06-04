using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HolidaySharp;

namespace HolidaySharp
{
    /// <summary>
    /// 24节气的C值
    /// </summary>
    internal class SolarTerm
    {
        private static readonly float D = 0.2422f;
        internal float C { get; private set; }
        internal int Month { get; private set; }
        internal string SolarTermName { get; private set; }
        internal SolarTerms? CurrentSolarTerms { get; set; }

        private static Dictionary<SolarTerms, float> Century21C = new Dictionary<SolarTerms, float>()
        {
            {
                SolarTerms.LICHUN, 3.87f
            },
            {
                SolarTerms.YUSHUI, 18.73f
            },
            {
                SolarTerms.JINGZHE, 5.63f
            },
            {
                SolarTerms.CHUNFEN, 20.646f
            },
            {
                SolarTerms.QINGMING, 4.81f
            },
            {
                SolarTerms.GUYU, 20.1f
            },
            {
                SolarTerms.LIXIA, 5.52f
            },
            {
                SolarTerms.XIAOMAN, 21.04f
            },
            {
                SolarTerms.MANGZHONG, 5.678f
            },
            {
                SolarTerms.XIAZHI, 21.37f
            },
            {
                SolarTerms.XIAOSHU, 7.108f
            },
            {
                SolarTerms.DASHU, 22.83f
            },
            {
                SolarTerms.LIQIU, 7.5f
            },
            {
                SolarTerms.CHUSHU, 23.13f
            },
            {
                SolarTerms.BAILU, 7.646f
            },
            {
                SolarTerms.QIUFEN, 23.042f
            },
            {
                SolarTerms.HANLU, 8.318f
            },
            {
                SolarTerms.SHUANGJIANG, 23.438f
            },
            {
                SolarTerms.LIDONG, 7.438f
            },
            {
                SolarTerms.XIAOXUE, 22.36f
            },
            {
                SolarTerms.DAXUE, 7.18f
            },
            {
                SolarTerms.DONGZHI, 21.94f
            },
            {
                SolarTerms.XIAOHAN, 5.4055f
            },
            {
                SolarTerms.DAHAN, 20.12f
            },
        };

        private static Dictionary<SolarTerms, float> Century20C = new Dictionary<SolarTerms, float>()
        {
            {
                SolarTerms.LICHUN, 4.6295f
            },
            {
                SolarTerms.YUSHUI, 19.4599f
            },
            {
                SolarTerms.JINGZHE, 6.3826f
            },
            {
                SolarTerms.CHUNFEN, 21.4155f
            },
            {
                SolarTerms.QINGMING, 5.59f
            },
            {
                SolarTerms.GUYU, 20.888f
            },
            {
                SolarTerms.LIXIA, 6.318f
            },
            {
                SolarTerms.XIAOMAN, 21.86f
            },
            {
                SolarTerms.MANGZHONG, 6.5f
            },
            {
                SolarTerms.XIAZHI, 22.2f
            },
            {
                SolarTerms.XIAOSHU, 7.928f
            },
            {
                SolarTerms.DASHU, 23.65f
            },
            {
                SolarTerms.LIQIU, 8.35f
            },
            {
                SolarTerms.CHUSHU, 23.95f
            },
            {
                SolarTerms.BAILU, 8.44f
            },
            {
                SolarTerms.QIUFEN, 23.822f
            },
            {
                SolarTerms.HANLU, 9.098f
            },
            {
                SolarTerms.SHUANGJIANG, 24.218f
            },
            {
                SolarTerms.LIDONG, 8.218f
            },
            {
                SolarTerms.XIAOXUE, 23.08f
            },
            {
                SolarTerms.DAXUE, 7.9f
            },
            {
                SolarTerms.DONGZHI, 22.6f
            },
            {
                SolarTerms.XIAOHAN, 6.11f
            },
            {
                SolarTerms.DAHAN, 20.84f
            },
        };

        private static Dictionary<int, Dictionary<SolarTerms, float>> CenturyC = new Dictionary<int, Dictionary<SolarTerms, float>>()
        {
            { 20, Century20C },
            { 21, Century21C },
        };

        internal SolarTerm(float c, int month, string name)
        {
            this.C = c;
            this.Month = month;
            this.SolarTermName = name;
            var solarTerms = GetSolarTerms(name);
            if (solarTerms != null)
            {
                this.CurrentSolarTerms = solarTerms;
            }
        }

        internal static IEnumerable<SolarTerm> GetSolarTerms()
        {
            return GetSolarTerms(DateTime.Now.Year);
        }

        internal static IEnumerable<SolarTerm> GetSolarTerms(int year)
        {
            double centuryF = year / 100f;
            int century = Convert.ToInt32(Math.Ceiling(centuryF));
            if (!CenturyC.ContainsKey(century)) throw new ArgumentException("no support data for century: " + century);
            FieldInfo[] fields = typeof(SolarTerms).GetFields();
            IEnumerable<SolarTerm> solarTerms = new List<SolarTerm>();
            Dictionary<SolarTerms, float> centuryC = CenturyC[century];
            foreach (var item in fields)
            {
                SolarTermDescriptionAttribute attr = item.GetCustomAttribute<SolarTermDescriptionAttribute>();
                if (attr != null)
                {
                    SolarTerms solarTerm = (SolarTerms)item.GetValue(attr);
                    float c = centuryC[solarTerm];
                    solarTerms = solarTerms.Append(new SolarTerm(c, attr.Month, attr.Name));
                }
            }

            return solarTerms;
        }

        internal static SolarTerm GetSolarTerm(string name, int year)
        {
            double centuryF = year / 100f;
            int century = Convert.ToInt32(Math.Ceiling(centuryF));
            if (!CenturyC.ContainsKey(century)) throw new ArgumentException("no support data for century: " + century);
            FieldInfo[] fields = typeof(SolarTerms).GetFields();
            Dictionary<SolarTerms, float> centuryC = CenturyC[century];
            foreach (var item in fields)
            {
                SolarTermDescriptionAttribute attr = item.GetCustomAttribute<SolarTermDescriptionAttribute>();
                if (attr != null && attr.Name == name)
                {
                    SolarTerms solarTerm = (SolarTerms)item.GetValue(attr);
                    float c = centuryC[solarTerm];
                    return new SolarTerm(c, attr.Month, attr.Name);
                }
            }

            return null;
        }

        internal static SolarTerm GetSolarTerm(DateTime solarTime)
        {
            int year = solarTime.Year;
            int month = solarTime.Month;
            int day = solarTime.Day;
            double centuryF = year / 100f;
            int century = Convert.ToInt32(Math.Ceiling(centuryF));
            if (!CenturyC.ContainsKey(century)) throw new ArgumentException("no support data for century: " + century);
            FieldInfo[] fields = typeof(SolarTerms).GetFields();
            Dictionary<SolarTerms, float> centuryC = CenturyC[century];
            foreach (var item in fields)
            {
                SolarTermDescriptionAttribute attr = item.GetCustomAttribute<SolarTermDescriptionAttribute>();
                if (attr != null && attr.Month == month)
                {
                    SolarTerms solarTerm = (SolarTerms)item.GetValue(attr);
                    float c = centuryC[solarTerm];
                    DateTime? time = CalcSolarTermTime(year, month, c, solarTerm);
                    if (time != null && time.Value.Day == day)
                    {
                        return new SolarTerm(c, attr.Month, attr.Name);
                    }
                }
            }

            return null;
        }

        internal static DateTime? CalcSolarTermTime(int year, int month, float c, SolarTerms? solarTerms)
        {
            if (solarTerms == null)
            {
                return null;
            }

            string _yStr = year.ToString();
            int y = Convert.ToInt32(_yStr.Substring(_yStr.Length - 2));
            float d = D;
            decimal l = y / 4;
            decimal left = Convert.ToDecimal(y * d + c);

            int _left = Convert.ToInt32(Math.Floor(left));
            int _right = Convert.ToInt32(Math.Floor(l));
            int day = _left - _right;
            var offsetSolarTerm = CalcSolarTermTimeWhenOffset(year, solarTerms);
            DateTime time = new DateTime(year, month, day);
            if (offsetSolarTerm != null)
            {
                time = time.AddDays(offsetSolarTerm.Offset);
            }

            SolarTermDescriptionAttribute attr = GetSolarTermAttribute(solarTerms.Value);

            if (attr != null && attr.NextYear)
            {
                time = time.AddYears(1);
            }

            return time;
        }

        internal static OffsetSolarTerm CalcSolarTermTimeWhenOffset(int year, SolarTerms? solarTerm)
        {
            if (solarTerm == null)
            {
                return null;
            }

            var offsetSolarTerms = OffsetSolarTerm.GetOffsetSolarTerms();
            return offsetSolarTerms.FirstOrDefault(r => r.SolarTerm == solarTerm && r.Year == year);
        }

        private static SolarTermDescriptionAttribute GetSolarTermAttribute(SolarTerms solarTerms)
        {
            FieldInfo _field = solarTerms.GetType().GetField(solarTerms.ToString());
            IEnumerable<SolarTermDescriptionAttribute> objs = _field.GetCustomAttributes<SolarTermDescriptionAttribute>();
            if (objs == null || objs.Count() == 0)
            {
                return null;
            }

            return objs.FirstOrDefault();
        }

        private static SolarTerms? GetSolarTerms(string name)
        {
            FieldInfo[] fields = typeof(SolarTerms).GetFields();
            Type descriptionType = typeof(SolarTermDescriptionAttribute);
            foreach (FieldInfo field in fields)
            {
                bool isDefined = field.IsDefined(descriptionType);
                var attr = field.GetCustomAttribute(descriptionType, false);
                if (isDefined && (attr as SolarTermDescriptionAttribute).Name == name)
                {
                    object obj = field.GetCustomAttribute(descriptionType, false);
                    SolarTerms t = (SolarTerms)field.GetValue(obj);
                    return t;
                }
            }

            return null;
        }
    }
}
