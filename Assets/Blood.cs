using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("BloodSplatter");

        Invoke("DestroyObject", 0.4f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

}
