using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenCam : MonoBehaviour
{
    public GameObject cam1, cam2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            cam2.SetActive(false);
            cam1.SetActive(true);
        }
    }
}
