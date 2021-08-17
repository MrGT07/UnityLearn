using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forSecondCam : MonoBehaviour
{
     public GameObject player;
    private Vector3 offset = new Vector3(0, 4, 1);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
