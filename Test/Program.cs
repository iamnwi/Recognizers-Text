using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Recognizers.Text.DateTime.English;
using Microsoft.Recognizers.Text.DateTime.Chinese;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.DateTime.Tests.English;
using Newtonsoft.Json;
using Microsoft.Recognizers.Text.DateTime.English.Tests;
using Microsoft.Recognizers.Text.DateTime.Chinese.Tests;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            //list.Add("an hour and a half");
            //list.Add("half hour");
            //list.Add("an hour and a quarter");
            //list.Add("two and a half hours");
            //list.Add("after May");
            //list.Add("after 7/2");
            //list.Add("since 7/2");
            //list.Add("after last week");
            //list.Add("upcoming month holidays");
            //list.Add("next month holidays");
            //list.Add("I'll be out between 5 and 6pm");
            list.Add("from 1am to 5pm");

            //list.Add("帮我定一个从现在到八点的会议");
            //list.Add("今晚八点到九点有会议室吗");
            //list.Add("帮我在今晚7点到7点30定个会");
            //list.Add("从昨天下午两点到明天四点");
            //list.Add("帮我定一个下午三到四点的会");
            //list.Add("再过三年半");
            //list.Add("三个半月");
            //list.Add("三日半");

            Test(list);

            //FormalTest();
        }

        static void Test(List<string> list)
        {
            foreach (var text in list)
            {
                TestOne(text);
            }
            Console.WriteLine("\n");
            Console.ReadLine();
        }

        static void TestOne(string text)
        {
            //var p = new FullDateTimeParser(new ChineseDateTimeParserConfiguration());
            //var e = new MergedExtractorChs();
            var p = new BaseMergedParser(new EnglishMergedParserConfiguration());
            var e = new BaseMergedExtractor(new EnglishMergedExtractorConfiguration());
            DateTimeModel dtModel = new DateTimeModel(p, e);

            DateTime refTime = DateTime.Now;
            var pr = dtModel.Parse(text, refTime);
            Console.WriteLine(JsonConvert.SerializeObject(pr));
            
            
        }

        static void FormalTest()
        {
            //EN
            var e = new TestDurationExtractor();
            var p = new TestDurationParser();
            e.TestDurationExtract();
            p.TestDurationParse();

            //CHS
            /*var p = new TestDateTimePeriodChsParser();
            p.TestDateTimePeriodParseChs();*/
        }
    }
}