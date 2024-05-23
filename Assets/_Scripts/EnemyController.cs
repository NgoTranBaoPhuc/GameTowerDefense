using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    private Path thePath;
    private int currentPoint;
    private bool reachedEnd;

    // Start is called before the first frame update
    void Start()
    {
        thePath = FindObjectOfType<Path>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedEnd)
        {
            transform.LookAt(thePath.points[currentPoint]);

            transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
            {
                currentPoint++;
                if (currentPoint >= thePath.points.Length)
                {
                    reachedEnd = true;
                }
            }
        } 
    }
}
