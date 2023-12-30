namespace SnakeGame;

public class Engine
{
    public static int debugValue = 0;

    private static List<GameObject> objectList = [];

    public static List<GameObject> ObjectList { get => objectList; set => objectList = value; }
}
