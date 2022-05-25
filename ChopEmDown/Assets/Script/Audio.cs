using Newtonsoft.Json;
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
        // read
        string filepath = "user.json";
        var users = new List<ClassUser.UserInfo>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            users = JsonConvert.DeserializeObject<List<ClassUser.UserInfo>>(json);
        }

        // update
        foreach (var item in users)
        {
            ismMusic = item.isMusic;
            ismSound = item.isSound;
        }

        // save
        using (StreamWriter w = new StreamWriter(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(w, users);
        }
    }

    public void UpdateSound()
    {
        // read
        string filepath = "user.json";
        var users = new List<ClassUser.UserInfo>();
        using (StreamReader r = new StreamReader(Application.dataPath + "/DataFile.json"))
        {
            var json = r.ReadToEnd();
            users = JsonConvert.DeserializeObject<List<ClassUser.UserInfo>>(json);
        }

        // update
        foreach (var item in users)
        {
            item.isMusic = ismMusic;
            item.isSound = ismSound;
        }

        // save
        using (StreamWriter w = new StreamWriter(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(w, users);
        }
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





    public void AddUser2()
    {
        ClassUser.UserInfo userInfo = new ClassUser.UserInfo();
        userInfo.points = 0;
        userInfo.bestPoints = 0;
        userInfo.isMusic = true;
        userInfo.isSound = false;
        userInfo.items = new List<ClassUser.GameItem>();

        string json = JsonUtility.ToJson(userInfo);
        File.WriteAllText(Application.dataPath + "/DataFile.json", json);
    }





    public void AddUser()
    {
        ClassUser.UserInfo userInfo = new ClassUser.UserInfo();
        userInfo.points = 0;
        userInfo.bestPoints = 0;
        userInfo.isMusic = true;
        userInfo.isSound = true;
        userInfo.items = new List<ClassUser.GameItem>();

        string filepath = "user.json";
        var users = new List<ClassUser.UserInfo>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            users = JsonConvert.DeserializeObject<List<ClassUser.UserInfo>>(json);
            // kiem tra username ton tai
            if (users == null) users = new List<ClassUser.UserInfo>();

        }

        users.Add(userInfo);
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, users);
        }
    }
}
