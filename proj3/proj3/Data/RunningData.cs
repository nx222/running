internal record RunningData
{
    public decimal Distance { get; init; } = decimal.Round(new decimal(new Random().NextDouble() * 10), 2);
    public TimeSpan Time { get; init; } = new TimeSpan(new Random().Next(0, 1), new Random().Next(0, 60), new Random().Next(20, 60));
    public Map Map { get; init; } = new Map();

    public override string ToString()
    {
        return $"Data: distance - {Distance.ToString("0.00")}km, time - {Time.ToString("c")}";
    }

    public static IEnumerable<RunningData> CreateData()
    {
        var data = new List<RunningData>();

        var maxDistance = decimal.Round(new decimal(new Random().NextDouble() * 10), 2);

        var maxHours = new Random().Next(2);
        var maxMinutes = maxHours > 0 ? new Random().Next(61) : new Random().Next(22, 61);

        var distanceInc = maxDistance / (maxHours * 60 + maxMinutes);

        var time = new TimeSpan(0, 0, 0);

        var distance = 0.00m;

        for (var j = 0; j <= maxHours; j++)
        {
            for (var i = 0; i < maxMinutes; i++)
            {
                data.Add(
                    new RunningData()
                    {
                        Distance = distance,
                        Time = time
                    }
                    );

                distance += distanceInc;

                time = time.Add(new TimeSpan(0, 1, 0));
            }
        }

        return data;
    }
}