using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    private Path thePath;
    private int currentPoint;
    private bool reachedEnd; //xác định điểm cuối của Path

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle theCastle;

    private int selectedAttackPoint;

    public bool isFlying;
    public float flyHeight;

    // Start is called before the first frame update
    void Start()
    {
        if (thePath == null)
        {
            thePath = FindAnyObjectByType<Path>();
        }//mỗi Spawn Enemy sẽ di chuyển trên Path của riêng nó 
        if (theCastle == null)
        {
            theCastle = FindAnyObjectByType<Castle>();
        }//mỗi Spawn Enemy sẽ tấn công caslte của riêng nó 

        if (isFlying)
        {
            transform.position += Vector3.up * flyHeight;
            currentPoint = thePath.points.Length - 1;
        }

        thePath = FindObjectOfType<Path>(); //Tìm các Object Path

        theCastle = FindObjectOfType<Castle>(); //Điều này là để Enemy biết chúng thực sự cần tấn công cái gì 

        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.levelActive)
        {


            if (!reachedEnd)
            {
                transform.LookAt(thePath.points[currentPoint]);

                if (!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
                    {
                        currentPoint++;
                        if (currentPoint >= thePath.points.Length)
                        {
                            reachedEnd = true;
                            selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                        }
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position + (Vector3.up * flyHeight), moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, thePath.points[currentPoint].position + (Vector3.up * flyHeight)) < .01f)
                    {
                        currentPoint++;
                        if (currentPoint >= thePath.points.Length)
                        {
                            reachedEnd = true;
                            selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                        }
                    }
                }
            }
            else
            {
                if(!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position + (Vector3.up * flyHeight), moveSpeed * Time.deltaTime);
                }

                attackCounter -= Time.deltaTime;

                if (attackCounter <= 0)
                {
                    attackCounter = timeBetweenAttacks;

                    theCastle.TakeDamage(damagePerAttack);
                }
            }
        }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        theCastle = newCastle;
        thePath = newPath;
    }
}
