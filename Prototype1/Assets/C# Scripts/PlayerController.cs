using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 15.0f;
    private float _turnSpeed = 10f;
    private float _horizontalInput;
    private float _forwardInput;
    
    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        //Move the vehicle right
        transform.Rotate(Vector3.up, _turnSpeed * _horizontalInput * Time.deltaTime);
    }
}
