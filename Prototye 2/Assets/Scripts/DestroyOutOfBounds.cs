using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 18;
    private float lowerBound = -6;
    private float leftBound = -27;
    private float rightBound = 27;
    private static int lives = 3, cnt = 0;
    void Update()
    {
        //If GameObject goes out of bounds, they get destroyed
        if (transform.position.z > topBound)
            Destroy(gameObject);
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            cnt++;
            if(cnt >= lives)
            {
                Debug.Log("Game Over!");
                Time.timeScale = 0f;
            }
        }

        if (transform.position.x < leftBound)
            Destroy(gameObject);

        if (transform.position.x > rightBound)
            Destroy(gameObject);
    }
}
