using System.Collections;

internal class RunningStat : IEnumerable<RunningData>
{
    private readonly IEnumerable<RunningData> _data;

    private readonly TimeSpan _every;

    public RunningStat(IEnumerable<RunningData> data, TimeSpan every)
    {
        if (every.TotalMinutes < 1)
        {
            throw new InvalidDataException("Interval must be greater than 1 minute");
        }

        if (every.TotalMinutes > 60)
        {
            throw new InvalidDataException("Interval must be less than or equal to 60 minutes");
        }

        _data = data;
        _every = every;
    }

    public static int GetEveryNMin(IEnumerable<RunningData> data)
    {
        var everyNMin = (int)Math.Floor(data.Select(data => data.Time).Max().TotalMinutes / new Random().Next(4, 8));

        while (everyNMin < 1)
        {
            everyNMin = (int)Math.Floor(data.Select(data => data.Time).Max().TotalMinutes / new Random().Next(4, 8));
        }

        return everyNMin;
    }

    public IEnumerator<RunningData> GetEnumerator()
    {
        return new RunningStatEveryEnumerator(_data, _every);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new RunningStatEveryEnumerator(_data, _every);
    }
}
