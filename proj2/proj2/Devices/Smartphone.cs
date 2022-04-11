internal class Smartphone : Running
{
    protected Run? current;

    public void BeginRun()
    {
        current = new Run();
    }

    public virtual void FinishRun()
    {
        var report = current.GetRunningData();
        Console.WriteLine(ToString());
        Display(report);

        Console.WriteLine("");
    }

    public void DisplayMap(Map map)
    {
        Console.WriteLine(map.ToString());
    }

    public void Display(RunningData data)
    {
        DisplayMap(data.Map);
        Console.WriteLine(data.ToString());
    }

    public override string ToString()
    {
        return "Smartphone";
    }
}
