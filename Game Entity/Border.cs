namespace SnakeGame;

public class Border : GameObject
{
    public Border()
    {
    }

    public Border(List<Pixel> body) : base(body)
    {
    }

    public static List<Pixel> CreateBorder(int xOffset = 0, int yOffset = 0, int bottomOffset = 0, int rightOffset = 0, ConsoleColor borderColor = ConsoleColor.White)
    {
        var border = new List<Pixel>();

        for (int y = yOffset; y <= Engine.height - yOffset; y++)
        {
            border.Add(new Pixel(0, y, borderColor));
            border.Add(new Pixel(Engine.width - rightOffset, y, borderColor));
        }

        for (int x = xOffset; x <= Engine.width - xOffset; x++)
        {
            border.Add(new Pixel(x, 0, borderColor));
            border.Add(new Pixel(x, Engine.height - bottomOffset, borderColor));
        }

        return border;
    }
}
