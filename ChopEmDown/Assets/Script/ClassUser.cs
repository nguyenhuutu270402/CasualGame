using System.Collections.Generic;



[System.Serializable]
public class ClassUser
{
    public int points;
    public int bestPoints;
    public bool isMusic;
    public bool isSound;
    public List<GameItem> items = new List<GameItem>();

}

[System.Serializable]
public class GameItem
{
    public int id;
    public string name;
    public bool isActive;
    public int price;
}
