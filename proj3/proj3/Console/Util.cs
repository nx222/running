namespace proj3.Util;

internal class Util
{
    private static void ResetCursor()
    {
        System.Console.SetCursorPosition(0, 0);
    }

    public static void Clear()
    {
        ResetCursor();

        for (var i = 0; i < System.Console.WindowHeight; i++)
            System.Console.WriteLine("".PadLeft(System.Console.WindowWidth));

        ResetCursor();
    }

    public static char ReadKey()
    {
        var key = System.Console.ReadKey().KeyChar.ToString().ToLower().ToCharArray()[0];
        Clear();
        return key;
    }
}
