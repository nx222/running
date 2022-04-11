internal record Range<T> where T : IComparable
{
    public T Min { get; init; }
    public T Max { get; init; }

    public Range(T min, T max)
    {
        if (min.CompareTo(max) > 0)
        {
            throw new InvalidOperationException($"Min cannot be greater than max. Got: {max.ToString()} < {min.ToString()}");
        }

        Min = min;
        Max = max;
    }

    public bool Contains(T value)
    {
        return Min.CompareTo(value) <= 0 && Max.CompareTo(value) >= 0;
    }
}
