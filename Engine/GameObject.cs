namespace SnakeGame;

public class GameObject
{
    public int debugValue = 0;

    private List<Pixel> body = [];
    public List<int[]> Skeleton { get; set;  } = [];
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
        updateSkeleton();
    }

    protected void updateSkeleton()
    {
        Skeleton = [];
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

        foreach (GameObject obj in objects)
        {

            IEnumerable<int[]> mathes = obj.Skeleton.Intersect(Skeleton);
        }

        return null;
    }
}