internal record RunningDataOperatorOptions
{
    public OperatorOption<TimeSpan>? intervalEvery { get; init; }
    public OperatorOption<Range<decimal>>? distance { get; init; }
    public OperatorOption<Range<TimeSpan>>? time { get; init; }
}