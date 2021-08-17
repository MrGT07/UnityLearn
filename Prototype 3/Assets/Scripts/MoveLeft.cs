using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 10;
    private PlayerController _playerControllerScript;
    private float _leftBound = -8f; 

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(_playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        
        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
