using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControll : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    public Transform[] sPoint;

    private int currentRandom;

    private float nextSpawn;
    private float timeToNextSpawn;

    void Start()
    {
        nextSpawn = 10f;
    }

    void FixedUpdate()
    {
        InstantEnemyInRandomPlaces();
    }

    void InstantEnemyInRandomPlaces()
    {
        if (timeToNextSpawn < nextSpawn)
        {
            timeToNextSpawn += Time.deltaTime;
        }
        else
        {
            currentRandom = Random.Range(0, sPoint.Length - 1);
            Instantiate(enemy, sPoint[currentRandom].transform.position, Quaternion.identity);
            timeToNextSpawn = 0f;

            if (nextSpawn > 2f)
            {
                nextSpawn--;
            }
            else
            {
                nextSpawn = 2f;
            }
        }

    }
}
