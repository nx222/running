internal record RunningData
{
    public decimal Distance { get; init; } = decimal.Round(new decimal(new Random().NextDouble() * 10), 2);
    public TimeSpan Time { get; init; } = new TimeSpan(new Random().Next(0, 1), new Random().Next(0, 60), new Random().Next(20, 60));
    public Map Map { get; init; } = new Map();

    public override string ToString()
    {
        return $"Data: distance - {Distance.ToString("0.00")}km, time - {Time.ToString("c")}";
    }
}
