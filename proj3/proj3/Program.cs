using static proj3.Util.Util;

start:

var data = RunningData.CreateData();

var everyNMin = RunningStat.GetEveryNMin(data);
var statEvery = new RunningDataEveryOperation(data, new TimeSpan(0, everyNMin, 0)).Process();

Console.WriteLine("Displaying stats every {0} minutes, up to 2km\n", everyNMin);

var upTo10Km = new RunningDataFilterOperation(statEvery, new Range<decimal>(0.00m, 2.00m)).Process();

upTo10Km.ToList().ForEach(data => Console.WriteLine(data.ToString()));

/*
 * Either enumerator can be used
var enumerator = statEvery.GetEnumerator();


while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current.ToString());
}
*/

Console.WriteLine("\nPress Q to exit.");

if (ReadKey() != 'q')
{
    Clear();
    goto start;
}
