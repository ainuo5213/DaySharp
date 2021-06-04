### 功能

HolidaySharp是一个用来计算中国阳历节日、农历节日和24节气的库；

### 兼容性

由于要支持农历，所以阳历和农历支持范围都为20世纪初到21实际末，即1901中国春节起到2099年春节前。

### 使用方法

所有节日返回值为

```c#
{
    "Name": "中秋节", // 节日名称
    "LunarTime": "", // 节日农历时间
    "SolarTime": "" // 节日阳历时间
}
```



#### 阳历节日

```C#
new SolarHoliday(holidayFullName); // 计算阳历节日
new SolarHoliday(month, day); // 计算今年某月某天阳历节日
new SolarHoliday(year, month, day); // 计算某年某月某日阳历节日
new SolarHoliday(solarTime); // 计算该时间的阳历节日
SolarHoliday.GetSolarMonthlyHolidays(); // 计算当前所在月的阳历节日
SolarHoliday.GetSolarMonthlyHolidays(month); // 计算今年某一月的阳历节日
SolarHoliday.GetSolarMonthlyHolidays(year, month); // 计算某年某一月的阳历节日
SolarHoliday.GetSolarMonthlyHolidays(solarTime); // 计算该时间所在月份的阳历节日
SolarHoliday.GetSolarYearlyHolidays(); // 计算今年的阳历节日
SolarHoliday.GetSolarYearlyHolidays(solarTime); // 计算该时间所在年的阳历节日
SolarHoliday.GetSolarYearlyHolidays(year); // 计算概念的阳历节日
SolarHoliday.GetSolarHoliday(); // 计算当前时间的阳历节日
SolarHoliday.GetSolarHoliday(month, day); // 计算今年某月某天的阳历节日
SolarHoliday.GetSolarHoliday(year, month, day); // 计算某年某月某天的阳历节日
SolarHoliday.GetSolarHoliday(solarTime); // 计算该时间的阳历节日
```

#### 农历节日

```c#
new LunarHoliday(name); // 计算农历节日
new LunarHoliday(lunarTime); // 计算农历时间对应的农历节日
new LunarHoliday(month, day); // 计算今年农历时间的某月某天所对应的农历节日
new LunarHoliday(year, month, day); // 计算某年农历时间的某月某天所对应的农历节日
LunarHoliday.GetLunarMonthlyHolidays(); // 计算当前所在月的农历节日
LunarHoliday.GetLunarMonthlyHolidays(month); // 计算今年农历某月的农历节日
LunarHoliday.GetLunarMonthlyHolidays(year, month); // 计算某年农历某月的农历节日
LunarHoliday.GetLunarMonthlyHolidays(lunarTime); // 该农历时间所在的月的农历节日
LunarHoliday.GetLunarYearlyHolidays(); // 当前阳历时间所在年的农历节日
LunarHoliday.GetLunarYearlyHolidays(lunarTime); // 某个阳历时间所在年的农历节日
LunarHoliday.GetLunarYearlyHolidays(year); // 某年的农历节日
LunarHoliday.GetLunarHoliday(); // 计算当前农历时间的农历节日
LunarHoliday.GetLunarHoliday(solarTime); // 计算该农历时间的农历节日
LunarHoliday.GetLunarHoliday(int month, int day); // 计算今年农历某月某天的农历节日
LunarHoliday.GetLunarHoliday(int year, int month, int day); // 计算农历某年某月某天的农历节日
```

#### 节气

```c#
new SolarTermHoliday(name); // 计算当前节气
new SolarTermHoliday(solarTime); // 计算当前阳历时间对应的节气
new SolarTermHoliday(year, month, day); // 计算阳历某年某月某天对应的节气
new SolarTermHoliday(month, day);- // 计算今年阳历某月某天所对应的节气
SolarTermHoliday.GetSolarTermMonthlyHolidays(); // 计算当前时间所在月的所有节气
SolarTermHoliday.GetSolarTermMonthlyHolidays(solarTime); // 计算该时间所在月的所有节气
SolarTermHoliday.GetSolarTermMonthlyHolidays(month); // 计算今年某月的所有节气
SolarTermHoliday.GetSolarTermMonthlyHolidays(year, month); // 计算某年某月的所有节气
SolarTermHoliday.GetSolarTermYearlyHolidays(year); // 计算该所在年的所有节气
SolarTermHoliday.GetSolarTermYearlyHolidays(); // 计算今年的所有节气
SolarTermHoliday.GetSolarTermYearlyHolidays(solarTime); // 计算该所在年的所有节气
SolarTermHoliday.GetSolarTermHoliday(); // 计算当前时间所在天的节气
SolarTermHoliday.GetSolarTermHoliday(solarTime); // 计算该时间所在天的节气
SolarTermHoliday.GetSolarTermHoliday(month, day); // 计算今年某月某天所在的节气
SolarTermHoliday.GetSolarTermHoliday(year, month, day); // 计算某年某月某天所在的节气
```

