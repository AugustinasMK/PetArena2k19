using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager instance = null;
  public static string level = "Bedroom";

  public static int player1Hero = 1;
  public static int player2Hero = 2;

  void Awake() {
    if (instance == null) {
      instance = this;
    } else if (instance == this) {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);
  }

  public static void LoadLevel() {
    UnityEngine.SceneManagement.SceneManager.LoadScene(level, UnityEngine.SceneManagement.LoadSceneMode.Single);
  }

  public static void LoadMainMenu() {
    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single);
  }
}
