using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogUltimate : MonoBehaviour {

  public Animator animator;
  public KeyCode key;
  public float ultimateDuration = 5f;

  UltimateLauncher ultimateLauncher;

  public ParticleSystem effect;

  PoopSpawner poopSpawner;

  public void SetPlayer1Key() {
    key = KeyCode.X;
  }

  public void SetPlayer2Key() {
    key = KeyCode.M;
  }

  // Start is called before the first frame update
  void Start() {
    animator = GetComponent<Animator>();
    ultimateLauncher = GetComponentInChildren<UltimateLauncher>();
    poopSpawner = FindObjectOfType<PoopSpawner>();

  }

  // Update is called once per frame
  void Update() {
    if (Time.timeScale == 1) {
      if (Input.GetKeyDown(key)) {
  
        EnableUltimate();
      }
    }
  }

  public void EnableUltimate() {

        animator.SetBool("CastingUltimate", true);
        ultimateLauncher.EnableLauncher();
    poopSpawner.EnableSpawner(gameObject);
        if (!effect.isPlaying)
            effect.Play();
    CameraShake.Shake(ultimateDuration, 0.5f);
    Invoke("DisableUltimate", ultimateDuration);
  }



  public void DisableUltimate() {
    ultimateLauncher.DisableLauncher();
    poopSpawner.DisableSpawner();
        if (effect.isPlaying)
            effect.Stop();
        animator.SetBool("CastingUltimate", false);
  }


}
