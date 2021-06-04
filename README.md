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
SolarHoliday.GetMonthlyHolidays(month); // 计算今年某一月的阳历节日
SolarHoliday.GetMonthlyHolidays(year, month); // 计算某年某一月的阳历节日
SolarHoliday.GetMonthlyHolidays(solarTime); // 计算该时间所在月份的阳历节日
SolarHoliday.GetYearlyHolidays(); // 计算今年的阳历节日
SolarHoliday.GetYearlyHolidays(solarTime); // 计算该时间所在年的阳历节日
SolarHoliday.GetYearlyHolidays(year); // 计算概念的阳历节日
```

#### 农历节日

```c#
new LunarHoliday(name); // 计算农历节日
new LunarHoliday(lunarTime); // 计算农历时间对应的农历节日
new LunarHoliday(month, day); // 计算今年农历时间的某月某天所对应的农历节日
new LunarHoliday(year, month, day); // 计算某年农历时间的某月某天所对应的农历节日
LunarHoliday.GetMonthlyHolidays(month); // 计算今年农历某月的农历节日
LunarHoliday.GetMonthlyHolidays(year, month); // 计算某年农历某月的农历节日
LunarHoliday.GetMonthlyHolidays(lunarTime); // 该农历时间所在的月的农历节日
LunarHoliday.GetYearlyHolidays(); // 当前阳历时间所在年的农历节日
LunarHoliday.GetYearlyHolidays(lunarTime); // 某个阳历时间所在年的农历节日
LunarHoliday.GetYearlyHolidays(year); // 某年的农历节日
```

#### 节气

```c#
new SolarTermHoliday(name); // 计算当前节气
new SolarTermHoliday(solarTime); // 计算当前阳历时间对应的节气
new SolarTermHoliday(year, month, day); // 计算阳历某年某月某天对应的节气
new SolarTermHoliday(month, day);- // 计算今年阳历某月某天所对应的节气
SolarTermHoliday.GetSolarTermHolidays(); // 计算今年的所有节气
SolarTermHoliday.GetSolarTermHolidays(year); // 计算某年的所有节气
SolarTermHoliday.GetSolarTermHolidays(year, month); // 计算某年某月的节气
SolarTermHoliday.GetSolarTermHolidays(time); // 计算该所在年的所有节气
```

