namespace SnakeGame
{
    public class Fruit : GameObject
    {
        public ConsoleColor Color { get; set; }

        public Fruit() : base()
        {
            Name = "Apple";
            Body.Add(new Pixel());
            ChangePosition();
        }

        public void ChangePosition()
        {
            Body[0] = new Pixel(new Random().Next(5, 20), new Random().Next(5, 20), Color);
        }
    }
}
