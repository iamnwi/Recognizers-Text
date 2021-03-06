﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text.DateTime.English.Utilities;
using Microsoft.Recognizers.Text.DateTime.Utilities;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.Number.English;
using Microsoft.Recognizers.Definitions.English;

namespace Microsoft.Recognizers.Text.DateTime.English
{
    public class EnglishDateExtractorConfiguration : IDateExtractorConfiguration
    {
        public static readonly Regex MonthRegex =
            new Regex(
                DateTimeDefinitions.MonthRegex,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex DayRegex =
            new Regex(
                DateTimeDefinitions.DayRegex,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex MonthNumRegex =
            new Regex(DateTimeDefinitions.MonthNumRegex,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex YearRegex = new Regex(DateTimeDefinitions.YearRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex WeekDayRegex =
            new Regex(
                DateTimeDefinitions.WeekDayRegex,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex OnRegex = new Regex(DateTimeDefinitions.OnRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex RelaxedOnRegex =
            new Regex(
                DateTimeDefinitions.RelaxedOnRegex,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex ThisRegex = new Regex(DateTimeDefinitions.ThisRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex LastDateRegex = new Regex(DateTimeDefinitions.LastDateRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex NextDateRegex = new Regex(DateTimeDefinitions.NextDateRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex DateUnitRegex = new Regex(DateTimeDefinitions.DateUnitRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex SpecialDayRegex =
            new Regex(
                DateTimeDefinitions.SpecialDayRegex,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex StrictWeekDay =
            new Regex(
                DateTimeDefinitions.StrictWeekDay,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex WeekDayOfMonthRegex =
            new Regex(
                DateTimeDefinitions.WeekDayOfMonthRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex SpecialDate = new Regex(DateTimeDefinitions.SpecialDate,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex[] DateRegexList =
        {
            // (Sunday,)? April 5
            new Regex(
                DateTimeDefinitions.DateExtractor1,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // (Sunday,)? April 5, 2016
            new Regex(
                DateTimeDefinitions.DateExtractor2, RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // (Sunday,)? 6th of April
            new Regex(
                DateTimeDefinitions.DateExtractor3, RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 3-23-2017
            new Regex(DateTimeDefinitions.DateExtractor4,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 23-3-2015
            new Regex(DateTimeDefinitions.DateExtractor5,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // on 1.3
            new Regex(DateTimeDefinitions.DateExtractor6,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 7/23
            new Regex(DateTimeDefinitions.DateExtractor7,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // on 24-12
            new Regex(DateTimeDefinitions.DateExtractor8,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 23/7
            new Regex(DateTimeDefinitions.DateExtractor9,
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 2015-12-23
            new Regex(DateTimeDefinitions.DateExtractorA,
                RegexOptions.IgnoreCase | RegexOptions.Singleline)
        };


        public static readonly Regex[] ImplicitDateList =
        {
            OnRegex, RelaxedOnRegex, SpecialDayRegex, ThisRegex, LastDateRegex, NextDateRegex,
            StrictWeekDay, WeekDayOfMonthRegex, SpecialDate
        };

        public static readonly Regex OfMonth = new Regex(DateTimeDefinitions.OfMonth,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex MonthEnd = new Regex(DateTimeDefinitions.MonthEnd,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public EnglishDateExtractorConfiguration()
        {
            IntegerExtractor = new IntegerExtractor();
            OrdinalExtractor = new OrdinalExtractor();
            NumberParser = new BaseNumberParser(new EnglishNumberParserConfiguration());
            DurationExtractor = new BaseDurationExtractor(new EnglishDurationExtractorConfiguration());
            UtilityConfiguration = new EnlighDatetimeUtilityConfiguration();
        }

        public IExtractor IntegerExtractor { get; }

        public IExtractor OrdinalExtractor { get; }

        public IParser NumberParser { get; }

        public IExtractor DurationExtractor { get; }

        public IDateTimeUtilityConfiguration UtilityConfiguration { get; }

        IEnumerable<Regex> IDateExtractorConfiguration.DateRegexList => DateRegexList;

        IEnumerable<Regex> IDateExtractorConfiguration.ImplicitDateList => ImplicitDateList;

        Regex IDateExtractorConfiguration.OfMonth => OfMonth;

        Regex IDateExtractorConfiguration.MonthEnd => MonthEnd;

        Regex IDateExtractorConfiguration.DateUnitRegex => DateUnitRegex;
    }
}