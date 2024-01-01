namespace SnakeGame;

public class Fruit : GameObject
{
    public int Offset { get; set; } = 5;
    public ConsoleColor Color { get; set; }

    public Fruit(ConsoleColor color = ConsoleColor.Green) : base()
    {
        Color = color;
        Body.Add(new Pixel(new Random().Next(Engine.borderLeftOffset, Engine.width - Engine.borderRightOffset),
                new Random().Next(Engine.borderTopOffset, Engine.height - Engine.borderBottomOffset),
                Color));
        ChangePosition();
    }

    public void ChangePosition()
    {
        Body[0] = new Pixel
            (
                new Random().Next(Engine.borderLeftOffset, Engine.width - Engine.borderRightOffset) - Engine.borderThickness,
                new Random().Next(Engine.borderTopOffset, Engine.height - Engine.borderBottomOffset) - Engine.borderThickness, 
                Color
            );
    }
}
