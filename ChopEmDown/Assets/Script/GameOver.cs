using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI txtScoreBest;
    public TextMeshProUGUI txtScore;
    public Tap tap;
    public GameObject mySeasonObject;
    public static bool isSetting = false;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowGameOverCanvas()
    {
        txtScore.text = tap.getScore() + "";
        txtScoreBest.text = tap.getScoreBest() + "";
        tap.RemoveTap();
        gameObject.SetActive(true);
        
    }
    public void HideGameOverCanvas()
    {
        
    }

    public void Replay()
    {
        isSetting = false;
        tap.ResetGame();
        tap.ReStoreTap();
        mySeasonObject.GetComponent<RandomSeason>().randomSeason();
        gameObject.SetActive(false);
        Debug.Log("ON CLICK REPALY");
    }

    public void backHome()
    {
        SceneManager.LoadScene(0);
    }

    public void onSetting()
    {
        isSetting = true;
        gameObject.SetActive(false);
    }

}
