using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpeedup : MonoBehaviour
{
    // Start is called before the first frame update

    InGame inGame;
    AudioSource audioSource;

    public float speedFrom = 1f;
    public float speedTo = 1.2f;

    public float increment;

   

    void Start()
    {
        inGame = FindObjectOfType<InGame>();
        audioSource = GetComponent<AudioSource>();

        audioSource.pitch = speedFrom;

       

    }

    // Update is called once per frame
    void Update()
    {
       audioSource.pitch = Mathf.Lerp(speedFrom, speedTo, 1f - (inGame.currenctMatchTime / inGame.matchLength));    
    }
}
