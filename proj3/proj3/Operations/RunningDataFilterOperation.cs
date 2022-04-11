internal class RunningDataFilterOperation : RunningDataOperator
{
    public RunningDataFilterOperation(
            IEnumerable<RunningData> data,
            Range<TimeSpan> timeIn) : base(
                data,
                new RunningDataOperatorOptions
                {
                    time = new OperatorOption<Range<TimeSpan>>(timeIn)
                }
            )
    { }

    public RunningDataFilterOperation(
            IEnumerable<RunningData> data,
            Range<decimal> distanceIn) : base(
                data,
                new RunningDataOperatorOptions
                {
                    distance = new OperatorOption<Range<decimal>>(distanceIn),
                }
            )
    { }

    public RunningDataFilterOperation(
            IEnumerable<RunningData> data,
            Range<decimal> distanceIn,
            Range<TimeSpan> timeIn) : base(
                data,
                new RunningDataOperatorOptions
                {
                    distance = new OperatorOption<Range<decimal>>(distanceIn),
                    time = new OperatorOption<Range<TimeSpan>>(timeIn)
                }
            )
    { }

    public override void DistanceIn(Range<decimal> distance)
    {
        var result = Data.Where(d => distance.Contains(d.Distance));
        if (result.Any())
        {
            Data = result;
        }
    }

    public override void Every(TimeSpan interval)
    {
        throw new NotImplementedException();
    }

    public override void TimeIn(Range<TimeSpan> time)
    {
        var result = Data.Where(d => time.Contains(d.Time));

        if (result.Any())
        {
            Data = result;
        }
    }
}
