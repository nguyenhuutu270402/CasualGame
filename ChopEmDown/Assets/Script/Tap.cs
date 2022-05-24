using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tap : MonoBehaviour
{
    public TrunkManager trunkManager;
    public GameObject Player;
    private PlayerController playerController;
    private string Tapdirection = "1";
    private string branchDirection = "2";


    public GameObject GameOverCanvas;
    private GameOver gameOver;


    public GUIScript GUIScript;
    private float totalTime = 5.0f;
    private float currentTime;
    private int bestScore = 0;
    private int score = 0;
    public int getScore()
    {
        return score;
    }

    public int getScoreBest()
    {
        return bestScore;
    }


    private bool isGameOver = true;

    private bool isTimeCount = false;

    public GameObject TapLeft , TapRight;

    private float xRight = 0.593f;
    private float xLeft = -0.593f;


  

    void Start()
    {
        

        //TapLeft.transform.localPosition = new Vector3(xLeft, 500, TapLeft.transform.localPosition.z);
        //TapRight.transform.localPosition = new Vector3(xRight, 500, TapRight.transform.localPosition.z);

        currentTime = totalTime;

        playerController = Player.GetComponent<PlayerController>();

        gameOver = GameOverCanvas.GetComponent<GameOver>();
        ReadBestPoints();
    }
    void Update()
    {
        if (isTimeCount)
        {
            currentTime -= Time.deltaTime;
        }
        GUIScript.setBar(currentTime / totalTime);

        if (Input.GetMouseButtonDown(0))
        {

            

            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            if (hitInfo)
            {
                score++;
                GUIScript.setScore(score);
                currentTime += 0.13f;
                playerController.EnableCutAnimation();
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                HitAction(hitInfo);
            }
            
        }
        else
        {
                playerController.DisableCutAnimation();
        }

        if (Tapdirection == branchDirection || currentTime <= 0)
        {
            
            isGameOver = true;
            playerController.Dead();
            //TapLeft.transform.localPosition = new Vector3(xLeft, 500, TapLeft.transform.localPosition.z);
            //TapRight.transform.localPosition = new Vector3(xRight, 500, TapRight.transform.localPosition.z);

            if (bestScore < score)
            {
                bestScore = score;
                UpdateBestPoints();
            }

         if(GameOver.isSetting == false)
            {
                gameOver.ShowGameOverCanvas();
            }
            

        }

    }

    public void ResetGame()
    {

        isTimeCount = true;
        isGameOver = false;
        score = 0;
        GUIScript.setScore(score);
        currentTime = totalTime;
        Debug.Log(currentTime + "dmtruong");
        GUIScript.setBar(1);
        Tapdirection = "1";
        branchDirection = "2";
        playerController.Respawn();
        trunkManager.ResetTrunk();
        GUIScript.gameObject.SetActive(true);
        //TapLeft.transform.localPosition = new Vector3(xLeft, -0.499f, TapLeft.transform.localPosition.z);
        //TapRight.transform.localPosition = new Vector3(xRight, -0.499f, TapRight.transform.localPosition.z);
    }

    




    private void HitAction(RaycastHit2D hitInfo)
    {
        if (hitInfo.transform.gameObject.name == "TapRight")
        {
            Player.transform.localPosition = new Vector3(0.25f, -0.5f, 0);
            Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
            trunkManager.cutFirstTrunk();
            
            Tapdirection = "BranchRight";
            branchDirection = trunkManager.getFirstTrunkName();
            //Debug.Log(Tapdirection);

        }
        else
        {
            Player.transform.localPosition = new Vector3(-0.25f, -0.5f, 0);
            Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            trunkManager.cutFirstTrunk();
            Tapdirection = "BranchLeft";
            branchDirection = trunkManager.getFirstTrunkName();
            //Debug.Log(Tapdirection + "Tapdirection");

        }

        
    }

    public void RemoveTap()
    {
        TapLeft.transform.localPosition = new Vector3(xLeft, 500, TapLeft.transform.localPosition.z);
        TapRight.transform.localPosition = new Vector3(xRight, 500, TapRight.transform.localPosition.z);
    }

    public void ReStoreTap()
    {
        TapLeft.transform.localPosition = new Vector3(xLeft, -0.499f, TapLeft.transform.localPosition.z);
        TapRight.transform.localPosition = new Vector3(xRight, -0.499f, TapRight.transform.localPosition.z);
    }




    public void UpdateBestPoints()
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
            item.bestPoints = score;
        }

        // save
        using (StreamWriter w = new StreamWriter(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(w, users);
        }
    }

    public void ReadBestPoints()
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
            bestScore = item.bestPoints;
        }

        // save
        using (StreamWriter w = new StreamWriter(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(w, users);
        }
    }

}
