using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool active = false;

    public GameObject owner;

   

    private void OnCollisionEnter2D(Collision2D collision)
    {

      
        if (!active)
            return;

        Debug.Log(collision.collider.name);


        if (collision.collider.CompareTag("Player") && collision.collider.transform != owner.transform)
        {
            RangedAttack rangedAttack = owner.GetComponent<RangedAttack>();        
            Health health = collision.collider.GetComponent<Health>();
            health.InflictDamage(rangedAttack.damage);
            AudioSource.PlayClipAtPoint(rangedAttack.hitSound, Camera.main.transform.position);
                 
        }

        if (collision.collider.transform != owner.transform)
        {
            active = false;
        }
    }
}
