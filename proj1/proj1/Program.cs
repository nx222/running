using static proj1.Console.Util;

var running1 = Running.Instance;

running1.Start();

do
{
    Clear();
    Console.WriteLine($"running1 - {running1}");
    Console.WriteLine("Press any key to run. Otherwise, press Q to quit.");

    if (ReadKey() == 'q')
        running1.Suspend();
    else
        running1.Run();
    Clear();

} while (running1.IsRunning);

Clear();

Console.WriteLine($"running1 - {running1}");
Console.WriteLine();

var running2 = Running.Instance;

Console.WriteLine($"running2 - {running2}");
