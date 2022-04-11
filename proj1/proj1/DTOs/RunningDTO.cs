using proj1.Extensions;

internal abstract class RunningDTO
{
    protected UnitType units;

    protected RunningDTO(UnitType units)
    {
        this.units = units;

        TotalDistance = 0m;
        TotalTime = new TimeSpan(0, 0, 0);
    }

    public decimal TotalDistance { get; set; }
    public TimeSpan TotalTime { get; set; }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();

        switch (units)
        {
            case UnitType.Meters:
                sb.AppendLine($"Distance: {decimal.Round(TotalDistance)}{units.GetStringValue()}");
                break;
            default:
                sb.AppendLine($"Distance: {decimal.Round(TotalDistance, 2)}{units.GetStringValue()}");
                break;
        }

        sb.Append($"Time: {TotalTime.ToString("c")}");

        return sb.ToString();
    }
}
