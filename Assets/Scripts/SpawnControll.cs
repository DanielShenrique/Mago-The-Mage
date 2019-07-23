using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControll : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    public Transform[] sPoint;

    private int currentRandom;

    private float spawnRate;
    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 2;
        nextSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InstantEnemyInRandomPlaces();
    }

    void InstantEnemyInRandomPlaces()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            currentRandom = Random.Range(0, sPoint.Length - 1);
            Instantiate(enemy, sPoint[currentRandom].transform.position, Quaternion.identity);
        }
       
    }
}
