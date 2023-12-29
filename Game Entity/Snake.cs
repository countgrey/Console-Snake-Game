using SnakeGame;

namespace ConsoleSnakeGame
{
    public class Snake(List<Pixel> body) : GameObject(body)
    {
        private Pixel head = body[0];

        public Dictionary<string, Direction> directions = new()
        {
            { "Right" , new Direction(1, 0) },
            { "Left" , new Direction(-1, 0) },
            { "Up" , new Direction(0, 1) },
            { "Down" , new Direction(0, -1) }
        };

        public Direction Direction { get; }

        public void Crawl(Direction direction, bool pop = true)
        {
            if ( pop )
            {
                this.body.RemoveAt(this.body.Count - 1);
            }

        }
    }
}