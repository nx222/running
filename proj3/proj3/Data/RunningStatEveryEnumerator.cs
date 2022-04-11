using System.Collections;

internal class RunningStatEveryEnumerator : IEnumerator<RunningData>
{
    private readonly TimeSpan _every;
    private readonly IEnumerator<RunningData> enumerator;

    public RunningData Current => enumerator.Current;

    object IEnumerator.Current => enumerator.Current;

    public RunningStatEveryEnumerator(IEnumerable<RunningData> data, TimeSpan every)
    {
        _every = every;

        enumerator = data.GetEnumerator();
    }

    public void Dispose()
    {
        enumerator.Dispose();
    }

    private int GetMinutes(TimeSpan time)
    {
        return (int)Math.Floor(time.TotalMinutes);
    }

    public bool MoveNext()
    {
        var next = enumerator.MoveNext();

        if (next)
        {
            var isEvery = GetMinutes(Current.Time) % GetMinutes(_every) == 0;

            while (!isEvery)
            {
                if (enumerator.MoveNext())
                    isEvery = GetMinutes(Current.Time) % GetMinutes(_every) == 0;
                else
                    return false;
            }
        }
        
        return next;
    }

    public void Reset()
    {
        enumerator.Reset();
    }
}
