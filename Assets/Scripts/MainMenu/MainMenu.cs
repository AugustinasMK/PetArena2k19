using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
  public void Play() {
    UnityEngine.SceneManagement.SceneManager.LoadScene("Selection", UnityEngine.SceneManagement.LoadSceneMode.Single);
  }
  public void Quit() {
    Application.Quit();
  }
}
