using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public Image barRed;
    void Start()
    {
        setBar(-1f);
    }


    void Update()
    {

    }

    public void setScore(int value)
    {
        txtScore.text = value + "";
    }

    public void setBar(float percent)
    {
        float total = 673f;
        float p = total - (percent * total);
        barRed.transform.localPosition = new Vector3(0.2f - p, barRed.transform.localPosition.y, barRed.transform.localPosition.z);

    }
}
