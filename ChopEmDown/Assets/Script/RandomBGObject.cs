using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGObject : MonoBehaviour
{
    public GameObject Bird1, Bird2, Bird3, Bird4, Bird5 = null;

    private float timeLap, time = 10f;

    void Start()
    {
        timeLap = 0;
    }

    void Update()
    {
        timeLap -= Time.deltaTime;

        if (timeLap < 0)
        {
            RandomObject();
            timeLap = time;
        }
    }



    private GameObject RandomObject()
    {
        int randomNumber = 0;
        randomNumber = Random.Range(0, 6);
        GameObject bird = null;

        if (randomNumber == 1)
        {
            bird = Instantiate(Bird2, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0), ForceMode2D.Force);

            bird = Instantiate(Bird3, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(7, 0), ForceMode2D.Force);

            Destroy(bird, 20f);
        }
        if (randomNumber == 2)
        {
            bird = Instantiate(Bird2, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0), ForceMode2D.Force);

            bird = Instantiate(Bird4, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(11, 0), ForceMode2D.Force);

            bird = Instantiate(Bird5, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(7, 0), ForceMode2D.Force);

            Destroy(bird, 20f);
        }
        if (randomNumber == 3)
        {

            bird = Instantiate(Bird3, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0), ForceMode2D.Force);

            Destroy(bird, 20f);
        }
        if (randomNumber == 4)
        {
            bird = Instantiate(Bird1, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(13, 0), ForceMode2D.Force);

            Destroy(bird, 20f);
        }
        if (randomNumber == 5)
        {
            bird = Instantiate(Bird1, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 0), ForceMode2D.Force);

            bird = Instantiate(Bird2, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(16, 0), ForceMode2D.Force);

            bird = Instantiate(Bird4, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0), ForceMode2D.Force);

            Destroy(bird, 20f);
        }
        if (randomNumber == 6)
        {
            bird = Instantiate(Bird3, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(16, 0), ForceMode2D.Force);

            bird = Instantiate(Bird5, new Vector3(-1.5f, Random.Range(0.3f, 0.7f), 0f), Quaternion.identity);
            bird.GetComponent<Rigidbody2D>().AddForce(new Vector2(16, 0), ForceMode2D.Force);

            Destroy(bird, 20f);
        }

        return bird;

    }
}
