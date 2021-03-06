﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Chinese
{
    public class ChineseHolidayExtractorConfiguration : IHolidayExtractorConfiguration
    {
        public static readonly Regex LunarHolidayRegex =
            new Regex(
                $@"(({DatePeriodExtractorChs.YearRegex}|{
                        DatePeriodExtractorChs.YearInChineseRegex
                    }|(?<yearrel>明年|今年|去年))(的)?)?(?<holiday>除夕|春节|中秋节|中秋|元宵节|端午节|端午|重阳节)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex[] HolidayRegexList =
        {
            new Regex(
                $@"(({DatePeriodExtractorChs.YearRegex}|{
                        DatePeriodExtractorChs.YearInChineseRegex
                    }|(?<yearrel>明年|今年|去年))(的)?)?(?<holiday>新年|五一|劳动节|元旦节|元旦|愚人节|圣诞节|植树节|国庆节|情人节|教师节|儿童节|妇女节|青年节|建军节|女生节|光棍节|双十一|清明节|清明)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline),
            new Regex(
                $@"(({DatePeriodExtractorChs.YearRegex}|{
                        DatePeriodExtractorChs.YearInChineseRegex
                    }|(?<yearrel>明年|今年|去年))(的)?)?(?<holiday>母亲节|父亲节|感恩节|万圣节)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline),
            LunarHolidayRegex
        };
        
        public IEnumerable<Regex> HolidayRegexes => HolidayRegexList;
    }
}