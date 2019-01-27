using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steroids: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var catUlt = collision.GetComponent<CatUlti>();
            var dogUlt = collision.GetComponent<DogUltimate>();

            if (catUlt != null)
            {
                catUlt.ActivateUlt();
            } else if (dogUlt != null)
            {
                dogUlt.EnableUltimate();
            }

            Destroy(gameObject);
        }

        
    }
}
