using UnityEngine;

public class SpawnManagerRua : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 5f, 5f);
    }

    void SpawnEnemies()
    {
        int count = spawnPoints.Length;
        int index = Random.Range(0, count);
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
    }
}
