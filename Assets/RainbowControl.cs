using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowControl : MonoBehaviour
{

    private void Awake()
    {
        
        if (GetComponent<PlayerMovement>().facingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
