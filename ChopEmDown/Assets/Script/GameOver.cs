using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI txtScoreBest;
    public TextMeshProUGUI txtScore;
    public Tap tap;

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
        gameObject.SetActive(true);
    }
    public void HideGameOverCanvas()
    {
        gameObject.SetActive(false);
    }

    public void Replay()
    {
        HideGameOverCanvas();
        tap.ResetGame();

    }
}
