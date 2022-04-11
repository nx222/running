internal class WatchesMap : Smartphone
{
    private Watches _watches;

    public WatchesMap(Watches watches)
    {
        _watches = watches;
    }

    public override void FinishRun()
    {
        var report = current.GetRunningData();
        Console.WriteLine(ToString());

        DisplayMap(report.Map);
        _watches.DisplayTime(report);
        _watches.DisplayDistance(report);
        Console.WriteLine("");

    }

    public override string ToString()
    {
        return "Watches with map";
    }
}
