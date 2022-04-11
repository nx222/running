internal class Watches : Running
{
    protected Run? current;

    public void DisplayTime(RunningData data)
    {
        Console.WriteLine(data.Time.ToString("c"));
    }

    public void DisplayDistance(RunningData data)
    {
        Console.WriteLine(data.Distance.ToString("0.00") + "km");
    }

    public void BeginRun()
    {
        current = new Run();
    }

    public void FinishRun()
    {
        var report = current.GetRunningData();
        Console.WriteLine(ToString());
        DisplayTime(report);
        DisplayDistance(report);
        Console.WriteLine("");
    }

    public override string ToString()
    {
        return "Watches";
    }
}
