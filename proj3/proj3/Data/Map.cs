using System.Drawing;
using System.Text;

internal class Map
{
    private Point size = new(20, 12);

    public override string ToString()
    {
        var sb = new StringBuilder();

        for (var i = 0; i < size.Y; i++)
        {
            for (var j = 0; j < size.X; j++)
            {
                if (i == 0 || i == size.Y - 1)
                    sb.Append('-');
                else
                {
                    if (j == 0 || j == size.X - 1)
                        sb.Append('|');
                    else
                    {
                        if (j == size.X / 2 - 1)
                            sb.Append('M');
                        else if (j == size.X / 2)
                            sb.Append('A');
                        else if (j == size.X / 2 + 1)
                            sb.Append('P');
                        else
                            sb.Append(' ');
                    }
                }
            }
            sb.Append('\n');
        }

        return sb.ToString();
    }
}
