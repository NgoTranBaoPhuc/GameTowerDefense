using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public LayerMask whatIsEnemy;

    private Collider[] colliderInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    public float checkTime = .2f;

    [HideInInspector]
    public bool enemiesUpdate;

    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            enemiesInRange.Clear();
            foreach (Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
            enemiesUpdate = true;
        }
    }
}
