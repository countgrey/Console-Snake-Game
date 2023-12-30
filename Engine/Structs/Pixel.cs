namespace SnakeGame;

public readonly struct Pixel(int x, int y, ConsoleColor color = ConsoleColor.White)
{
    private readonly char _char = '█';

    public int X { get; } = x;
    public int Y { get; } = y;
    public int[] Position { get; } = [x, y];
    public ConsoleColor Color { get; } = color;

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        //Console.ForegroundColor = Color;
        Console.Write(_char);
    }
}
