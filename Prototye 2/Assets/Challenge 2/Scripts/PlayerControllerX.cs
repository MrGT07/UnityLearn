using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool _allowSpan = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_allowSpan)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                _allowSpan = false;
                Invoke("_resetBool", 2);
            }
        }
    }

    private void _resetBool()
    {
        _allowSpan = true;
    }
}
