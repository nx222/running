internal abstract class RunningDataOperator
{
    private IEnumerable<RunningData> _data;
    private RunningDataOperatorOptions _options;

    protected IEnumerable<RunningData> Data
    { 
        get => _data;
        set
        {
            if (!value.Any())
            {
                throw new InvalidDataException("Data cannot be empty.");
            }

            _data = value;
        }   
    }

    public RunningDataOperator(IEnumerable<RunningData> data, RunningDataOperatorOptions options)
    {
        _data = data;
        _options = options;
    }

    public IEnumerable<RunningData> Process()
    {
        if (_options.intervalEvery is not null)
            Every(_options.intervalEvery.Value);
        if (_options.distance is not null)
            DistanceIn(_options.distance.Value);
        if (_options.time is not null)
            TimeIn(_options.time.Value);
        return _data;
    }

    public abstract void Every(TimeSpan interval);

    public abstract void DistanceIn(Range<decimal> distance);

    public abstract void TimeIn(Range<TimeSpan> time);
}
