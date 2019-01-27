using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Player { PLAYER_1, PLAYER_2 };
public enum Hero { Cat, Dog };
public class PlayerInfo : MonoBehaviour {

  public Player player;
  public Hero hero;
  public Text text;

  private void Start() {
    text = GetComponent<Text>();

    if (player == Player.PLAYER_1) {
      text.text = "Player 1";
      text.color = Color.red;
    } else {
      text.text = "Player 2";
      text.color = Color.blue;
    }
    if (hero == Hero.Cat) {
      text.fontSize = 150;
    }
  }
}
