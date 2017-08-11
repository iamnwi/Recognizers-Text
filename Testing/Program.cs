using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Recognizers;
using Microsoft.Recognizers.Text.DateTime;
using Newtonsoft.Json;
using Microsoft.Recognizers.Text.DateTime.English;
using Microsoft.Recognizers.Text.DateTime.Chinese;
using Microsoft.Recognizers.Text.DateTime.English.Tests;

namespace Testing
{
    class Test
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            /*list.Add("an hour and a half");
            list.Add("an hour and half");
            list.Add("half hour");*/
            list.Add("two hour and a quarter");
            /*list.Add("3hrs and a half");
            list.Add("an hour");
            list.Add("two hours and 2 men will be there");
            list.Add("1.5 hour");*/

            TestList(list);
            //TestOne(text);
            //FormalTest();
        }

        private static void TestList(List<string> list)
        {
            foreach (string text in list)
            {
                TestOne(text);
            }

            Console.ReadLine();
        }
        private static void TestOne(string text)

        {
            var mergedParser = new BaseMergedParser(new EnglishMergedParserConfiguration());
            var mergedExtractor = new BaseMergedExtractor(new EnglishMergedExtractorConfiguration());

            //var mergedParser = new FullDateTimeParser(new ChineseDateTimeParserConfiguration());
            //var mergedExtractor = new MergedExtractorChs();

            var dtModel = new DateTimeModel(mergedParser, mergedExtractor);

            DateTime refTime = DateTime.Now;

            //string text = "half hour";

            var pr = dtModel.Parse(text, refTime);

            Console.WriteLine(JsonConvert.SerializeObject(pr));

            Console.WriteLine();

        }

        private static void FormalTest()
        {
            var test = new TestDurationExtractor();
            test.TestDurationExtract();
        }

}
}
