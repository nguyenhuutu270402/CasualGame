using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public Tap tap;
    public GameObject myAudioObject;

    // Start is called before the first frame update
    void Start()
    {
        // ch?y 2 l?n ?? ko b? l?i. ch?a tìm ra cách fix
        myAudioObject.GetComponent<Audio>().AddUser();
        myAudioObject.GetComponent<Audio>().AddUser();
        // read audio
        myAudioObject.GetComponent<Audio>().ReadSound();
        myAudioObject.GetComponent<Audio>().setActiveButtonAudio();



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
