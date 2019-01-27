using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDestruct : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject explosionEffect;
    public AudioClip explosionSoundEffect; // TODO more random sounds
    PoopSpawner poopSpawner;


    private void Start()
    {
        poopSpawner = FindObjectOfType<PoopSpawner>();
        Invoke("DestroyObject", 4f);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") &&  poopSpawner.caster != collider.gameObject)
        {
            collider.GetComponent<Health>().InflictDamage(20f);  // Fix
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSoundEffect, Camera.main.transform.position);
            DestroyObject();
        }        
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
