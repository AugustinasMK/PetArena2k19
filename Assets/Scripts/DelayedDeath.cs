using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDeath : MonoBehaviour
{
    
    void Start()
    {
        Invoke("DeleteExplosion", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void DeleteExplosion()
    {
        Destroy(gameObject);
    }
}
