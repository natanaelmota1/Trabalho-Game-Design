using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0.5f, 0.5f);
    }

    void SpawnEnemies()
    {
        int index = Random.Range(0, 3);
        Instantiate(portal, spawnPoints[index].position, Quaternion.identity);
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
    }
}
