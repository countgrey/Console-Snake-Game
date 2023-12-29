namespace SnakeGame
{
    public class GameObject
    {
        protected List<Pixel> body = [];

        public GameObject(List<Pixel> body)
        {
            this.body = body;
        }

        public GameObject() { }

        public void Draw()
        {
            foreach (Pixel pix in body) 
            {
                pix.Draw();
            }
        }
    }
}