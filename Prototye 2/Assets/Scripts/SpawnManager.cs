using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array of Animals Prefabs
    public GameObject[] animalPrefabs;
    private int _animalIndex;
    private float xPos = 20;
    private float zPos = 18;

    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;

    private void Start()
    {
        //Calling method for spawing random animals from above after _spawnInterval time
        InvokeRepeating("_spawnRandomAnimals", _startDelay, _spawnInterval);
    }

    //Method for spawning random animals
    private void _spawnRandomAnimals()
    {
        //Generating random position for animals
        Vector3 spawnPos = new Vector3(Random.Range(-xPos, xPos), 0, zPos);
        //Generating random index for animals
        _animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[_animalIndex], spawnPos, animalPrefabs[_animalIndex].transform.rotation);
    }
}
