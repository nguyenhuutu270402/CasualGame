using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    void Start()
    {
        currentTime = totalTime;

        playerController = Player.GetComponent<PlayerController>();

        gameOver = GameOverCanvas.GetComponent<GameOver>();
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
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
            if (bestScore < score)
            {
                bestScore = score;
            }

            gameOver.ShowGameOverCanvas();

            
        }

    }

    public void ResetGame()
    {
        isGameOver = false;
        score = 0;
        GUIScript.setScore(score);
        currentTime = totalTime;
        GUIScript.setBar(1);
        playerController.Respawn();
        trunkManager.ResetTrunk();
        GUIScript.gameObject.SetActive(true);
    }




    private void HitAction(RaycastHit2D hitInfo)
    {
        if (hitInfo.transform.gameObject.name == "TapRight")
        {
            Player.transform.localPosition = new Vector3(0.25f, -0.77f, 0);
            Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
            trunkManager.cutFirstTrunk();
            
            Tapdirection = "BranchRight";
            branchDirection = trunkManager.getFirstTrunkName();
            //Debug.Log(Tapdirection);

        }
        else
        {
            Player.transform.localPosition = new Vector3(-0.25f, -0.77f, 0);
            Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            trunkManager.cutFirstTrunk();
            Tapdirection = "BranchLeft";
            branchDirection = trunkManager.getFirstTrunkName();
            //Debug.Log(Tapdirection + "Tapdirection");

        }

        
    }

}