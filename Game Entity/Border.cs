namespace SnakeGame;

public class Border : GameObject
{
    private ConsoleColor color = ConsoleColor.White;

    public Border(ConsoleColor _color = ConsoleColor.White, int borderThickness = 1) : base()
    {
        color = _color;
        for (int i = 0; i < borderThickness; i++)
        {
            body.AddRange(CreateBorder(color, i));
        }
    }

    private static List<Pixel> CreateBorder(ConsoleColor borderColor, int offset)
    {
        var border = new List<Pixel>();

        for (int y = Engine.borderTopOffset + offset; y <= Engine.height - (Engine.borderBottomOffset + offset); y++)
        {
            border.Add(new Pixel(Engine.borderLeftOffset + offset, y, borderColor));
            border.Add(new Pixel(Engine.width - (Engine.borderRightOffset + offset), y, borderColor));
        }

        for (int x = Engine.borderLeftOffset + offset; x <= Engine.width - (Engine.borderRightOffset + offset); x++)
        {
            border.Add(new Pixel(x, Engine.borderTopOffset + offset, borderColor));
            border.Add(new Pixel(x, Engine.height - (Engine.borderBottomOffset + offset), borderColor));
        }

        return border;
    }
}
