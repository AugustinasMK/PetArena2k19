using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
  public GameObject gameUI;
  public void Resume() {
    if (Time.timeScale == 0) {
      Time.timeScale = 1;
      this.gameObject.SetActive(false);
      gameUI.SetActive(true);
    }
  }
  public void Restart() {
    GameManager.LoadLevel();
    Time.timeScale = 1;
  }
  public void Exit() {
    GameManager.LoadMainMenu();
    Time.timeScale = 1;
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Resume();
    }
  }
}
