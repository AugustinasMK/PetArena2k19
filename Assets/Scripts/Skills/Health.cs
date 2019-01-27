using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
  public Transform deathPreFab;
  public Transform deathPreFabBOT;
  private bool fell = false;
  public int fallBoundary = -20;
  public float health = 100f;
  public SimpleHealthBar bar;
  private GameObject getGO;
  private GameObject getBOT;
  private CameraControl getComponentAudio;
  private bool Dead = false;
  public delegate void Died();
  public event Died OnDie;
  public GameObject bloodGO;
  void Start() {
    getGO = GameObject.Find("Game Master");
    getComponentAudio = getGO.GetComponent<CameraControl>();
    getBOT = GameObject.Find("BottomBorder");
  }
  public void Update() {
    if (transform.position.y <= fallBoundary) {
      InflictDamage(health);
      fell = true;
    }
  }

  public void InflictDamage(float damage) {
    health -= damage;
    bar.UpdateBar(health, 100f);
    Transform bloodSpawn = GetComponentInChildren<BloodSpawn>().transform;

    Instantiate(bloodGO, bloodSpawn.position, Quaternion.identity);
    if (health <= 0 && Dead != true) {
      Dead = true;
      getComponentAudio.playsound();
      Invoke("Die", 0.45f);
    }
  }

  public void Heal(float heal) {
    health += heal;
    if (health > 100) health = 100;
    bar.UpdateBar(health, 100f);
  }

  public void Die() {

    //fishy part
    try {
      //ble nx neiseina kitaip krc
      GameObject.Find("Canvas In-game").GetComponent<InGame>().EndGame();
    } catch {
      //shit
    }
    //

    if (fell != true) {
      Instantiate(deathPreFab, transform.position, transform.rotation);
      Destroy(transform.root.gameObject);
    } else {
      transform.position = new Vector2(transform.position.x, getBOT.transform.position.y);
      Instantiate(deathPreFabBOT, transform.position, transform.rotation);
      Destroy(transform.root.gameObject);
    }
  }

  private void Health_OnDie() {
    //throw new System.NotImplementedException();
    //test thow
    Debug.Log("Throw here(1)");
  }
}
