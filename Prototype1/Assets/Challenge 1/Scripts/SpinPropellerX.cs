using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    private float rotateSpeed = 10f;
    public GameObject propeller;
    void Update()
    {
        propeller.transform.Rotate(new Vector3(0, 0, 1), rotateSpeed);
    }
}
