internal class RunningDataEveryOperation : RunningDataOperator
{
    public RunningDataEveryOperation(
            IEnumerable<RunningData> data,
            TimeSpan interval
            ) : base(
                data,
                new RunningDataOperatorOptions
                {
                    intervalEvery = new OperatorOption<TimeSpan>(interval)
                }
            )
    { }

    public override void DistanceIn(Range<decimal> distance)
    {
        // Do nothing
    }

    public override void Every(TimeSpan interval)
    {
        var result = new RunningStat(Data, interval);
        if (result.Any())
        {
            Data = result;
        }
    }

    public override void TimeIn(Range<TimeSpan> time)
    {
        // Do nothing
    }
}
