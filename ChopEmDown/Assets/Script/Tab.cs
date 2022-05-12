using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0)
        //{

        //    Input.GetTouch(0);
        //    Debug.Log("Touch" + Tap.name);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked");
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.gameObject.name);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                if(hitInfo.transform.gameObject.name == "TapRight")
                {
                    Player.transform.localPosition = new Vector3(0.25f, -0.77f, 0);
                    Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                if (hitInfo.transform.gameObject.name == "TapLeft")
                {
                    Player.transform.localPosition = new Vector3(-0.25f, -0.77f, 0);
                  
                    Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                   
                }
            }
        }



    }

    
}
