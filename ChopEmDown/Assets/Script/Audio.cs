using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music, sound;
    public AudioClip clip;
    bool ismMusic, ismSound;
    public Button btOnMusic, btOnSounds, btOffMusic, btOffSound;
    
    void Start()
    {
        ReadSound();
        setActiveButtonAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMusic()
    {
        ismMusic = true;
        UpdateSound();
        setActiveButtonAudio();
    }

    public void offMusic()
    {
        ismMusic = false;
        UpdateSound();
        setActiveButtonAudio();
    }

    public void onSound()
    {
        ismSound = true;
        UpdateSound();
        setActiveButtonAudio();
    }

    public void offSound()
    {
        ismSound = false;
        UpdateSound();
        setActiveButtonAudio();
    }



    public void ReadSound()
    {
        // Read data
        string jsonRead = File.ReadAllText(Application.dataPath + "/DataUser.json");
        ClassUser dataFile = JsonUtility.FromJson<ClassUser>(jsonRead);

        //read sound
        ismMusic = dataFile.isMusic;
        ismSound = dataFile.isSound;
    }

    public void UpdateSound()
    {
        // Read data
        string jsonRead = File.ReadAllText(Application.dataPath + "/DataUser.json");
        ClassUser dataFile = JsonUtility.FromJson<ClassUser>(jsonRead);

        //update
        dataFile.isMusic = ismMusic;
        dataFile.isSound = ismSound;

        //Save data
        string json = JsonUtility.ToJson(dataFile, true);
        File.WriteAllText(Application.dataPath + "/DataUser.json", json);
    }


    public void setActiveButtonAudio()
    {
        
        if (ismMusic == true)
        {
            music.mute = false;
            btOnMusic.gameObject.SetActive(true);
            btOffMusic.gameObject.SetActive(false);
            
        }
        if (ismMusic == false)
        {
            music.mute = true;
            btOnMusic.gameObject.SetActive(false);
            btOffMusic.gameObject.SetActive(true);
            
        }
        if (ismSound == true)
        {
            sound.mute = false;
            btOnSounds.gameObject.SetActive(true);
            btOffSound.gameObject.SetActive(false);
        }
        if (ismSound == false)
        {
            sound.mute = true;
            btOnSounds.gameObject.SetActive(false);
            btOffSound.gameObject.SetActive(true);
        }
    }


    public void playSoundChop()
    {
        sound.PlayOneShot(clip);
    }






    public void AddUser()
    {
        try
        {
            string jsonRead = File.ReadAllText(Application.dataPath + "/DataUser.json");
            ClassUser dataFile0 = JsonUtility.FromJson<ClassUser>(jsonRead);
            if (dataFile0 == null)
            {
                ClassUser dataFile = new ClassUser();
                dataFile.points = 0;
                dataFile.bestPoints = 0;
                dataFile.isMusic = true;
                dataFile.isSound = true;
                dataFile.items = new List<GameItem>();

                string json = JsonUtility.ToJson(dataFile, true);

                File.WriteAllText(Application.dataPath + "/DataUser.json", json);
            }
        }
        catch (Exception e)
        {
            File.WriteAllText(Application.dataPath + "/DataUser.json", "");
        }
    }
}
