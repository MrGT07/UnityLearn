using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoForward : MonoBehaviour
{
    public GameObject moveIt;
    void Update()
    {
        moveIt.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
    }
}
