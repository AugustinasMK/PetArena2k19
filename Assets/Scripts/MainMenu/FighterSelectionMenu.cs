using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSelectionMenu : MonoBehaviour {
  public GameObject pl1c;   //player 1 cat
  public GameObject pl1d;   //player 1 dog
  public GameObject pl2c;   //player 2 cat
  public GameObject pl2d;   //player 2 dog
  public UnityEngine.UI.Text TimerText;    //timer text
  private float timer = 0f;       //timer
  private float waitTime = 1f;    //time to count to in seconds
  int i = 10;                     //max number of cycles (number of seconds)

  void Awake() {
    Time.timeScale = 1;
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Return)) {         //if enter is pressed end selection
      CompleteChoosing();
    }
    if (Input.GetKeyDown(KeyCode.A)) {              //if player 1 pressed a
      if (pl1d.activeSelf == true) {
        pl1d.SetActive(false);
        pl1c.SetActive(true);
      }
    }
    if (Input.GetKeyDown(KeyCode.D)) {              //if player 1 pressed d
      if (pl1c.activeSelf == true) {
        pl1c.SetActive(false);
        pl1d.SetActive(true);
      }
    }
    if (Input.GetKeyDown(KeyCode.J)) {              //if player 2 pressed j
      if (pl2d.activeSelf == true) {
        pl2d.SetActive(false);
        pl2c.SetActive(true);
      }
    }
    if (Input.GetKeyDown(KeyCode.L)) {             //if player 2 pressed l
      if (pl2c.activeSelf == true) {
        pl2c.SetActive(false);
        pl2d.SetActive(true);
      }
    }


    if (i > 0) {
      timer += Time.deltaTime;

      if (timer > waitTime) { //one second has passed
        i--;
        TimerText.text = i.ToString();
        if (i <= 0) {
          CompleteChoosing();
        }
        timer = 0f;
      }
    }
  }

  void CompleteChoosing() {
    //Player 1
    if (pl1c.activeSelf == true) {
      GameManager.player1Hero = 1;
    } else {
      GameManager.player1Hero = 2;
    }

    //Pleyer 2
    if (pl2c.activeSelf == true) {
      GameManager.player2Hero = 1;
    } else {
      GameManager.player2Hero = 2;
    }

    GameManager.LoadLevel();
  }
}
