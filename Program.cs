using System.Reflection;
using System.Runtime.CompilerServices;

namespace SnakeGame;

class Program
{
    private const int width = 50;
    private const int height = 50;

    private const ConsoleColor borderColor = ConsoleColor.White;

    public static GameObject Border;

    protected static void Init()
    {
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width, height);
        Console.CursorVisible = false;

        Border = new(CreateBorder(1, 1, 1, 1));

    }

    private static int Loop()
    {
        Border.Draw();
        return 0;
    }

    public static void Main()
    {
        Init();

        for( ; ; )
        {
            if (Loop() !=0 ) break;
            System.Threading.Thread.Sleep(3);
            Console.Clear();
        }
    }

    private static List<Pixel> CreateBorder(int xOffset = 0, int yOffset = 0, int bottomOffset = 0, int rightOffset = 0)
    { 
        var border = new List<Pixel>();
        
        for (int y = yOffset; y <= height - yOffset; y++)
        {
            border.Add(new Pixel(0, y, borderColor));
            border.Add(new Pixel(width-rightOffset, y, borderColor));
        }

        for (int x = xOffset; x <= width - xOffset; x++)
        {
            border.Add(new Pixel(x, 0, borderColor));
            border.Add(new Pixel(x, height-bottomOffset, borderColor));
        }

        return border;
    }
}