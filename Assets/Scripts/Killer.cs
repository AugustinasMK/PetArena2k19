using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public Transform deathPreFab;
    public AudioSource Deathbruh;
    public AudioSource Deathoof;
    public AudioSource Deathsteve;
    public AudioSource Deathtoasty;
    public AudioSource Deathwilhelm;

    public void KillPlayer(Transform root, int rand)
    { 
        switch (rand)
        {
            case 1:
                
                Instantiate(deathPreFab, root.position, root.rotation);
                Destroy(root.gameObject);
                break;
            case 2:
                Instantiate(deathPreFab, root.position, root.rotation);
                Destroy(root.gameObject);
                break;
            case 3:
                Instantiate(deathPreFab, root.position, root.rotation);
                Destroy(root.gameObject);
                break;
            case 4:
                Instantiate(deathPreFab, root.position, root.rotation);
                Destroy(root.gameObject);
                break;
            case 5:
                Instantiate(deathPreFab, root.position, root.rotation);
                Destroy(root.gameObject);
                break;

            default:
                Instantiate(deathPreFab, root.position, root.rotation);
                Destroy(root.gameObject);
                break;
        }
    }
   
}
