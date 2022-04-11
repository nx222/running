using proj1.Extensions;

internal class RunningIntervalDTO : RunningDTO
{
    public RunningIntervalDTO(UnitType units) : base(units) { }

    public TimeSpan AvgTime
    {
        get
        {
            if (TotalDistance > 0)
            {
                var distance = (double)TotalDistance;
                if (units == UnitType.Meters)
                    distance /= 100;

                var result = TotalTime.Divide(distance);
                var formatted = new TimeSpan(result.Hours, result.Minutes, result.Seconds);
                return formatted;
            }

            return new TimeSpan(0, 0, 0);
        }
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine(base.ToString());
        if (units == UnitType.Meters)
            sb.Append($"Average time (100{units.GetStringValue()}): {AvgTime.ToString("c")}");
        else
            sb.Append($"Average time (1{units.GetStringValue()}): {AvgTime.ToString("c")}");

        return sb.ToString();
    }
}
