using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

  public KeyCode castKey = KeyCode.E;
  public AudioClip attackSound;
  public AudioClip hitSound;

  public float damage = 2f;
  public float cooldown = 1f;

  public float attackTime = 0f;

  public float attackRadius = 0.3f;

  public float projectileSpeed = 50f;
  public GameObject attackCastPoint;
  public Animator anim;

  public GameObject projectilePrefab;

  public void SetPlayer1Key() {
    castKey = KeyCode.E;
  }
  public void SetPlayer2Key() {
    castKey = KeyCode.O;
  }

  private void Awake() {
    anim = GetComponent<Animator>();

  }


  public void LaunchProjectile() {



    GameObject projectileGO = Instantiate(projectilePrefab, attackCastPoint.transform.position, Quaternion.identity);

    Projectile projectile = projectileGO.GetComponent<Projectile>();

    projectile.owner = gameObject;


    Rigidbody2D rigidbody2D = projectileGO.GetComponent<Rigidbody2D>();


    Debug.Log(transform.right);
    Vector2 dir = transform.localScale.x > 0 ? -transform.right : transform.right;
    anim.Play("Ranged Attack");
    AudioSource.PlayClipAtPoint(attackSound, Camera.main.transform.position);

    rigidbody2D.AddRelativeForce((dir * projectileSpeed) + (Vector2)transform.up * 200f);
    projectile.active = true;


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
          LaunchProjectile();
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
