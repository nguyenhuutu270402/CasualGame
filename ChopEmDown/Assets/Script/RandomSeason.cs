using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeason : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spring, Summer, Fall, Winter;
    void Start()
    {
        randomSeason();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomSeason()
    {
        int rd = Random.Range(0, 4);
        if (rd == 0)
        {
            Spring.SetActive(true);
            Summer.SetActive(false);
            Fall.SetActive(false);
            Winter.SetActive(false);
        }
        if (rd == 1)
        {
            Spring.SetActive(false);
            Summer.SetActive(true);
            Fall.SetActive(false);
            Winter.SetActive(false);
        }
        if (rd == 2)
        {
            Spring.SetActive(false);
            Summer.SetActive(false);
            Fall.SetActive(true);
            Winter.SetActive(false);
        }
        if (rd == 3)
        {
            Spring.SetActive(false);
            Summer.SetActive(false);
            Fall.SetActive(false);
            Winter.SetActive(true);
        }
        Debug.Log("rd" + rd);
    }
}
