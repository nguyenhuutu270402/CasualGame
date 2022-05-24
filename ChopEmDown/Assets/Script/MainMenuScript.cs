using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public Tap tap;
    // Start is called before the first frame update
    void Start()
    {
        tap.RemoveTap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        tap.ResetGame();
        tap.ReStoreTap();
        gameObject.SetActive(false);
    }
}
