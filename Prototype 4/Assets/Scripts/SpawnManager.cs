using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefab = new List<GameObject>();
    public GameObject[] powerUpPrefabs;
    private float _spawnRange = 9;
    private int _enemyCount;
    private int _waveNumber = 1;

    private void Start()
    {
        int randomPowerup = Random.Range(0, powerUpPrefabs.Length);
        _spawnEnemyWave(_waveNumber);
        Instantiate(powerUpPrefabs[randomPowerup], _generateRandomPos() + new Vector3(0, 0.5f, 0), powerUpPrefabs[randomPowerup].transform.rotation);
    }

    private void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;
        if(_enemyCount == 0)
        {
            _waveNumber++;
            _spawnEnemyWave(_waveNumber);
            int randomPowerup = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[randomPowerup], _generateRandomPos() + new Vector3(0, 0.5f, 0), powerUpPrefabs[randomPowerup].transform.rotation);
        }
    }

    private Vector3 _generateRandomPos()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void _spawnEnemyWave(int _enemiesToSpawn)
    {
        int ind = Random.Range(0, enemyPrefab.Count);
        for(int i=0; i<_enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[ind], _generateRandomPos(), enemyPrefab[ind].transform.rotation);
        }
    }
}
