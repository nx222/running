using System.Text;
using proj1.Extensions;
using static proj1.Console.Util;
using static proj1.Extensions.EnumExtensions;


internal class Running
{
    private static Running? instance;
    private decimal distance;
    private Stopwatch stopwatch;

    public StatType StatType { get; set; }
    public UnitType Units { get; set; }

    private Running() => Init();

    public static Running Instance
    {
        get
        {
            if (instance is null)
                instance = new Running();

            return instance;
        }
    }

    public void Start() => stopwatch.Start();

    public void Suspend() => stopwatch.Suspend();

    public void Stop()
    {
        stopwatch.Stop();
        distance = 0.00m;
    }

    public void Run()
    {
        switch (Units)
        {
            case UnitType.Kilometers:
                distance += new decimal(new Random().NextDouble() * 0.00025);
                break;
            case UnitType.Miles:
                distance += new decimal(new Random().NextDouble() * 0.0001553);
                break;
            case UnitType.Meters:
                distance += new decimal(new Random().NextDouble() * 0.25);
                break;
            default:
                throw new Exception("Unknown exception occurred.");
        }
    }

    public bool IsRunning { get => stopwatch.IsRunning; }

    private RunningDTO CreateRunningDTO()
    {
        switch (StatType)
        {
            case StatType.Velocity:
                return new RunningVelocityDTO(Units)
                {
                    TotalDistance = distance,
                    TotalTime = stopwatch.Time
                };
            case StatType.Interval:
                return new RunningIntervalDTO(Units)
                {
                    TotalDistance = distance,
                    TotalTime = stopwatch.Time
                };
            default:
                throw new InvalidDataException("Invalid type provided");
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Current run state: {stopwatch.State.GetStringValue()}");
        sb.AppendLine(CreateRunningDTO().ToString());
        return sb.ToString();
    }

    private void Init()
    {
        distance = 0.00m;
        stopwatch = new Stopwatch();
        StatType = StatType.Velocity;
        Units = UnitType.Kilometers;

        string ans;
        Console.WriteLine("Choose your stats type (VELOCITY/interval): ");
        ans = Interpolate(
            (Console.ReadLine()!).ToLower(),
            new string[]
            {
                StatType.Velocity.GetStringValue(),
                StatType.Interval.GetStringValue()
            }
        );
        StatType = GetStatType(ans);

        Console.WriteLine("Choose your units (KM/m/mi): ");
        ans = Interpolate(
            (Console.ReadLine()!).ToLower(),
            new string[]
            {
                UnitType.Kilometers.GetStringValue(),
                UnitType.Meters.GetStringValue(),
                UnitType.Miles.GetStringValue()
            }
        );
        Units = GetUnitType(ans);
    }
}
