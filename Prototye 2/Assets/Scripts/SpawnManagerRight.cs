using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerRight : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int _animalIndex;
    private float _startDelay = 2f;
    private float _spawnInterval = 1.5f;
    private float xPos = 26;
    private float zPosMin = 3, zPosMax = 13;

    private void Start()
    {
        InvokeRepeating("_spawnRandomAnimalsFromRightSide", _startDelay, _spawnInterval);
    }

    private void _spawnRandomAnimalsFromRightSide()
    {
        Vector3 spawnPos = new Vector3(xPos, 0, Random.Range(zPosMin, zPosMax));
        _animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[_animalIndex], spawnPos, animalPrefabs[_animalIndex].transform.rotation);
    }
}
