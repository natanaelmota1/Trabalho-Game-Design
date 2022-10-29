using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject boss;
    private int countSpawns;

    // Start is called before the first frame update
    void Start()
    {
        countSpawns = 0;
        InvokeRepeating("SpawnEnemies", 1f, 2f);
    }

    void SpawnEnemies()
    {
        int count = spawnPoints.Length;
        int index = Random.Range(0, count);
        if (countSpawns <= 10)
        {
            Instantiate(enemy, spawnPoints[index].position, Quaternion.identity); 
        }

        else if (countSpawns == 11)
        {
            Instantiate(boss, spawnPoints[index].position, Quaternion.identity);
        }
        countSpawns++;
    }
}
