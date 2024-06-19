using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;

    public float moveSpeed;
    public GameObject impactEffect;

    public float damageAmount;

    private bool hasDamaged; //Dùng để dí cho chết một con mới bắn con khác.

    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed;

        AudioManager.instance.PlaySFX(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            hasDamaged = true;
        }

        Instantiate(impactEffect,transform.position,Quaternion.identity);

        AudioManager.instance.PlaySFX(0);

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
