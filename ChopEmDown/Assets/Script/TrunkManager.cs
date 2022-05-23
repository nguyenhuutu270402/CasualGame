using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkManager : MonoBehaviour
{
    public GameObject trunkPrefab;
    public GameObject branchLeftPrefab;
    public GameObject branchRightPrefab;

    private bool isToCreateEmpty =  true;


    List<GameObject> branches;

    public GameObject Player;

    public float rotateSpeed = 15f;

    void Start()
    {
        branches = new List<GameObject>();

        for (int i = 0; i < 13; i+= 2)
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
    private void Update()
    {
        rotateSpeed += Time.deltaTime;
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

    public void cutFirstTrunk()
    {
        //Destroy(branches[0]);
        RemoveAndDestroyATrunk();
        branches.RemoveAt(0);

        int i = 0;
        for(i = 0; i < branches.Count; i++)
        {
            branches[i].transform.localPosition = new Vector3(branches[i].transform.localPosition.x, i * 0.2f, branches[i].transform.localPosition.z);
        }


        //Create an trunk
        GameObject trunk = Instantiate(isToCreateEmpty?trunkPrefab:getRandomBranch());
        trunk.transform.parent = gameObject.transform;
        trunk.transform.localPosition = new Vector3(0, i * 0.2f, 0);
        branches.Add(trunk);

        isToCreateEmpty = !isToCreateEmpty;

    }

    public string getFirstTrunkName()
    {
        string trunk;
        trunk = branches[0].transform.gameObject.tag;
        //Debug.Log(branches[0].transform.gameObject.tag + "in Trunk manager");
        return trunk;
    }


    public void ResetTrunk()
    {
        //remove all branches
        for (int i = 0; i < branches.Count; i++)
        {
            Destroy(branches[i]);
        }
        branches.RemoveRange(0, branches.Count);


        // Create new tree
        Start();
    }

    private void RemoveAndDestroyATrunk()
    {
        //float velocity = 50f;
        //float x = 0;
        if(Player.transform.localPosition.x > 0)
        {
            Debug.Log("trunk go LEFT");
            branches[0].transform.localRotation = Quaternion.Euler(Vector3.forward * 10*rotateSpeed);
            branches[0].GetComponent<Rigidbody2D>().AddForce(new Vector2(-250, 0), ForceMode2D.Force);

            //x -= Time.deltaTime;
            //branches[0].transform.localPosition = new Vector3(x * velocity, branches[0].transform.localPosition.y, branches[0].transform.localPosition.z);
            
        }
        else
        {
            Debug.Log("trunk go RIGHT");
            branches[0].transform.localRotation = Quaternion.Euler(Vector3.forward * 10 * -rotateSpeed);
            branches[0].GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 0), ForceMode2D.Force);

            //x += Time.deltaTime;
            //branches[0].transform.localPosition = new Vector3(x * velocity, branches[0].transform.localPosition.y, branches[0].transform.localPosition.z);
        }
        Destroy(branches[0], 2f);
    }
}
