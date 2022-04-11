namespace proj1.Console;

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

    public static string Interpolate(string input, IEnumerable<string> values)
    {
        if (!values.Any())
            throw new InvalidDataException("Expected values to be non-empty list");

        var result = values.Where(val => {
            if (val.Length >= input.Length)
            {
                return val.Substring(0, input.Length).Equals(input);
            }
            return false;
        });

        if (result.Any())
        {
            return result.First();
        }

        return values.First();
    }
}
