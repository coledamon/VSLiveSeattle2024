using Collatz;
using System.Numerics;
using Spackle;
using ReactiveDotNet.Core;
using SystemTimer = System.Timers.Timer;
using ReactiveDotNet;

var range = new Range<BigInteger>(2, 20_000_000);

DisplaySequence();

static void DisplaySequence()
{
    var sequence = CollatzSequenceGenerator.Generate(5);
    Console.WriteLine(string.Join(", ", sequence));
}

FindLongestSequence(range);

static void FindLongestSequence(Range<BigInteger> range)
{
    Console.WriteLine(nameof(FindLongestSequence));
    var currentStatistic = new SequenceStatistics(0, 0);
    for (var i = range.Start; i <= range.End; i++)
    {
        var sequence = CollatzSequenceGenerator.Generate(i);
        if(currentStatistic.Length < sequence.Length)
        {
            currentStatistic = new SequenceStatistics(i, sequence.Length);
            Console.WriteLine(currentStatistic);
        }
    }
}

FindLongestSequenceWithCallback(range, Console.WriteLine);

static void FindLongestSequenceWithCallback(Range<BigInteger> range, Action<SequenceStatistics> newLongSequence)
{
    Console.WriteLine(nameof(FindLongestSequenceWithCallback));
    var currentStatistic = new SequenceStatistics(0, 0);

    for (var i = range.Start; i <= range.End; i++) 
    {
        var sequence = CollatzSequenceGenerator.Generate(i);
        if (currentStatistic.Length < sequence.Length)
        {
            currentStatistic = new SequenceStatistics(i, sequence.Length);
            newLongSequence(currentStatistic);
        }
    }
}

//FindLongestSequenceWithTimer(range);

//static void FindLongestSequenceWithTimer(Range<BigInteger> range, )
//{
//    Console.WriteLine(nameof(FindLongestSequenceWithCallback));
//    var currentStatistic = new SequenceStatistics(0, 0);

//    using var timer = new SystemTimer()
//    for (var i = range.Start; i <= range.End; i++) 
//    {
//        var sequence = CollatzSequenceGenerator.Generate(i);
//        if (currentStatistic.Length < sequence.Length)
//        {
//            currentStatistic = new SequenceStatistics(i, sequence.Length);
//            (currentStatistic);
//        }
//    }
//}

static void FindLongestSequenceWithEnumeration(Range<BigInteger> range)
{
    Console.Write(nameof(FindLongestSequenceWithEnumeration));
    var sequences = new LongestSequenceEnumerable(range);

}



static void FindLongestSequenceWithEnumerationSimplified(Range<BigInteger>> range)
{
    static IEnumerable<SequenceStatistics> GetSequenceStaistics(Range<BigInteger> range)
    {
        var currentStatistic = new SequenceStatistics(0, 0);
        for (var i = range.Start; i <= range.End; i++)
        {

        }
}






