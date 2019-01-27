using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BasicAttack : MonoBehaviour {

  public KeyCode castKey = KeyCode.Q;
  public float damage = 2f;
  public float cooldown = 2f;

  public AudioClip[] basicAttackSounds;

  public AudioClip attackSound;

  public float attackTime = 0f;

  public float attackRadius = 0.3f;

  public GameObject attackCastPoint;
  public Animator anim;

  public void SetPlayer1Key() {
    castKey = KeyCode.Q;
  }

  public void SetPlayer2Key() {
    castKey = KeyCode.U;
  }

  private void Awake() {
    anim = GetComponent<Animator>();

  }


  public void Attack() {

    Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCastPoint.transform.position, attackRadius, 1 << LayerMask.NameToLayer("Player"));

    var result = colliders.Where(c => c.transform != transform);


    anim.Play("Close Attack");

    if (!result.Any()) {
      AudioSource.PlayClipAtPoint(basicAttackSounds[Random.Range(0, basicAttackSounds.Length - 1)], Camera.main.transform.position);
    } else {
      foreach (var col in result) {
        if (col.CompareTag("Player") && col.transform != transform) {
          Debug.Log("Enemy hit");
          Debug.Log(col.transform.name);
          Health health = col.GetComponent<Health>();
          //anim.SetBool("Attack", true);      
          AudioSource.PlayClipAtPoint(attackSound, Camera.main.transform.position);
          health.InflictDamage(damage);
          break;
        }
      }
    }

    attackTime = cooldown;
    //anim.SetBool("Attack", false);
  }


  // Update is called once per frame
  void Update() {
    if (Time.timeScale == 1) {
      attackTime -= Time.deltaTime;
      //anim.SetBool("Attack", false);

      if (Input.GetKeyDown(castKey)) {
        if (attackTime <= 0f) {
          Attack();
        }
      }
    }
  }

  private void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
    Gizmos.DrawWireSphere(attackCastPoint.transform.position, attackRadius);
  }
}
