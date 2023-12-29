namespace SnakeGame;

class Program
{
    private const int width = 100;
    private const int height = 100;

    private const ConsoleColor borderColor = ConsoleColor.White;

    public static void Main()
    {
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width+1, height+1);
        Console.CursorVisible = false;

        new Pixel(10, 10, borderColor).Draw();
        DrawBorder();

        Console.ReadKey();
    }

    private static void DrawBorder()
    {
        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                if (x == width-1 || y == height-1 || x == 0 || y == 1)
                {
                    new Pixel(x, y, borderColor).Draw();
                }
            }
            Console.WriteLine();
        }

    }
}