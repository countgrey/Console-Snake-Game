namespace SnakeGame;

public class GameObject
{
    public int debugValue = 0;

    protected List<Pixel> body = [];

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
        
    }


    public void Draw()
    {
        foreach (Pixel pix in body) 
        {
            pix.Draw();
        }
    }

    public GameObject? TouchedObject()
    {
        List<GameObject> objects = Engine.ObjectList;
        objects.Remove(this);
        foreach (GameObject obj in objects)
        {
            foreach (Pixel pos in obj.Body)
            {
                if((pos.X, pos.Y) == (Body.Last().X, Body.Last().Y)) return obj;
            }
        }

        return null;
    }
}