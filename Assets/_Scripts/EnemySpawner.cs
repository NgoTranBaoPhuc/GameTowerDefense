using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    public Transform spawnPoint;
    public float timeBetweenSpawns;
    private float spawnCouter;

    public int amountToSpawn = 10;

    public Castle theCastle;
    public Path thePath;
    void Start()
    {
        spawnCouter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0 && theCastle.currentHealth >0)
        {
            spawnCouter -= Time.deltaTime;
            if (spawnCouter <= 0)
            {
                spawnCouter = timeBetweenSpawns;

                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);

                amountToSpawn--;
            }
        }
    }
}
