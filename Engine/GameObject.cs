namespace SnakeGame;

public class GameObject
{
    public int debugValue = 0;

    private List<Pixel> body = [];
    public List<int[]> Skeleton { get; } = [];
    public string Name { get; set; } = "UntitledObject";

    public List<Pixel> Body
    { 
        get { return body; }
        set 
        { 
            body = value;
        }
    }

    public GameObject(List<Pixel> body) : base() => this.body = body;

    public GameObject()
    {
        foreach (Pixel pix in body)
        {
            Skeleton.Add([pix.X, pix.Y]);
        }
    }

    public void Draw()
    {
        foreach (Pixel pix in body) 
        {
            pix.Draw();
        }
    }


    private List<GameObject> objects = [];
    public GameObject? TouchedObject()
    {
        objects = Engine.ObjectList;
        objects.Remove(this);

        foreach(GameObject obj in objects)
        {
            foreach (int[] pos in Skeleton)
            {
                if (obj.Skeleton.Contains(pos)) return obj;
            }
        }

        return null;
    }
}