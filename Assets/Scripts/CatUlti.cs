using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatUlti : MonoBehaviour {
  // Start is called before the first frame update
  public bool smashAbsorbed = false;
  public Transform RSL;
  public KeyCode key;
  public GameObject Rainbow;
  public ParticleSystem Flare;
  public float ultDuration = 30f;
    private float currTime;
    public AudioClip brah_cat;
    public AudioSource audio;
    public float audioVolume;


    bool active = false;  

  public void SetPlayer1Key() {
    key = KeyCode.E;
  }
  public void SetPlayer2Key() {
    key = KeyCode.O;
  }

    public void ActivateUlt()
    {
        audio.volume = 0;
        active = true;
        currTime = ultDuration;

        GetComponent<RangedAttack>().enabled = false;
        GetComponentInChildren<UnityStandardAssets.Effects.AfterburnerPhysicsForce>(true).gameObject.SetActive(true);
        Invoke("DeactivateUlt", ultDuration);
        
    }

    void DeactivateUlt()
    {
        audio.volume = audioVolume;
        active = false;
        GetComponent<RangedAttack>().enabled = true;
        GetComponentInChildren<UnityStandardAssets.Effects.AfterburnerPhysicsForce>(true).gameObject.SetActive(false);
    }

    private void Start()
    {
        audio = Camera.main.GetComponent<AudioSource>();
        audioVolume = audio.volume;
        currTime = ultDuration;

    }


    // Update is called once per frame
    void Update() {
    //if (smashAbsorbed)
    if (active && Time.timeScale == 1) {
      currTime -= Time.deltaTime;
      if (currTime > 0) {
                if (!Flare.isPlaying)
                {
                    Flare.Play();
                    GetComponent<AudioSource>().clip = brah_cat;
                    GetComponent<AudioSource>().Play();
                }
                if (Input.GetKeyDown(key)) {
          var x = Instantiate(Rainbow, RSL.position, RSL.rotation);
          if (transform.localScale.x > 0) x.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
          else x.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
      } else {
        if (Flare.isPlaying) Flare.Stop();
      }
    }
  }
}
