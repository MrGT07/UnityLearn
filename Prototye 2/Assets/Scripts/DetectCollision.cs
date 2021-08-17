using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [HideInInspector]
    public static int score = 0;
    //Detect collision and destroy GameObject
    private void OnTriggerEnter(Collider other)
    {
        _increaseScore();
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

    private void _increaseScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
