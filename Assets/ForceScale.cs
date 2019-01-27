using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int multiplier = transform.parent.localScale.x > 0 ? 1 : -1;
        this.transform.localScale = new Vector3(-0.05f * multiplier, 0.05f, 0.05f);
    }
}
