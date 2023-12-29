namespace SnakeGame;

public readonly struct Pixel(int x, int y, ConsoleColor color)
{
    private readonly char _char = '█';

    public int X { get; } = x;
    public int Y { get; } = y;
    public ConsoleColor Color { get; } = color;

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(_char);
    }

    public void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");
    }
}
