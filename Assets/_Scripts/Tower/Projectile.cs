using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;

    public float moveSpeed;
    public GameObject impactEffect;

    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impactEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
