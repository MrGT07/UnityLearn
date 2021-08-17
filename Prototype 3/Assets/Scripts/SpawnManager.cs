using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);
    private float _startDelay = 1, _spawnInterval = 2;
    private PlayerController _playerControllerScript;

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("_spawnObstacles", _startDelay, _spawnInterval);
    }

    private void _spawnObstacles()
    {
        int ind = Random.Range(0, obstaclePrefab.Length);
        if(_playerControllerScript.gameOver == false)
            Instantiate(obstaclePrefab[ind], (obstaclePrefab[ind].transform.position + _spawnPos), obstaclePrefab[ind].transform.rotation);
    }

}
