using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUser : MonoBehaviour
{
    public class UserInfo
    {
        public int points { get; set; }
        public int bestPoints { get; set; }
        public bool isMusic { get; set; }
        public bool isSound { get; set; }
        public List<GameItem> items { get; set; } = new List<GameItem>();

    }


    public class GameItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
    }
}
