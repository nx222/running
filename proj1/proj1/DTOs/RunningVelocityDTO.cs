using proj1.Extensions;

internal class RunningVelocityDTO : RunningDTO
{
    public RunningVelocityDTO(UnitType units) : base(units) { }

    public decimal AvgVelocity
    {
        get
        {
            if (TotalTime.TotalSeconds > 0)
            {
                switch (units)
                {
                    case UnitType.Meters:
                        return decimal.Round(TotalDistance / new decimal(TotalTime.TotalSeconds));
                    default:
                        return decimal.Round(TotalDistance / new decimal(TotalTime.TotalHours), 2);
                }
            }
            return 0.00m;
        }
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine(base.ToString());

        if (units == UnitType.Meters)
            sb.Append($"Average velocity ({units.GetStringValue()}ps): {AvgVelocity}");
        else
            sb.Append($"Average velocity ({units.GetStringValue()}ph): {AvgVelocity}");

        return sb.ToString();
    }
}
