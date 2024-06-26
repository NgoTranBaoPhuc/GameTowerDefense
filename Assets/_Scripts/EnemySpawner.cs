using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public EnemyController enemyToSpawn;
    public EnemyController[] enemiesToSpawn;

    public Transform spawnPoint;
    public float timeBetweenSpawns;
    private float spawnCounter;

    public int amountToSpawn = 10;

    public Castle theCastle;
    public Path thePath;

    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0 && LevelManager.instance.levelActive)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);

                amountToSpawn--;
            }
        }
    }
}
