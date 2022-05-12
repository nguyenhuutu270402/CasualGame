using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkManager : MonoBehaviour
{
    public GameObject trunkPrefab;
    public GameObject branchLeftPrefab;
    public GameObject branchRightPrefab;

    List<GameObject> branches;

    void Start()
    {
        branches = new List<GameObject>();

        for (int i = 0; i < 10; i+= 2)
        {
            GameObject trunkEmpty = Instantiate(trunkPrefab);
            trunkEmpty.transform.parent = gameObject.transform;
            trunkEmpty.transform.localPosition = new Vector3(0, i*0.2f, 0);
            branches.Add(trunkEmpty);

            GameObject trunkBranch = Instantiate(getRandomBranch());
            trunkBranch.transform.parent = gameObject.transform;
            trunkBranch.transform.localPosition = new Vector3(0, (i+1) * 0.2f, 0);
            branches.Add(trunkBranch);
        }
       
    }

    private GameObject getRandomBranch()
    {
        int random = Random.Range(0, 100);
        if(random <= 10)
        {
            return trunkPrefab;
        }else if(random <= 60)
        {
            return branchLeftPrefab;
        }
        
            return branchRightPrefab;
       
    }


    void Update()
    {
        
    }
}
