using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGame : MonoBehaviour {
  public TextMeshProUGUI countdown;
  public TextMeshProUGUI endGameText;
  public GameObject pauseUI;
  public GameObject gameUI;
  public GameObject gameStartUI;
  public GameObject endgameUI;
  public GameObject Player1Spawn;
  public GameObject Player2Spawn;


  public GameObject Cat;
  public GameObject Dog;
  public SimpleHealthBar Player1StatusBar;
  public SimpleHealthBar Player2StatusBar;

  public float matchLength = 60.0f;
  public float currenctMatchTime;


  public float SpawnTime;
  float currentSpawnTime;
  public TextMeshProUGUI timer;
  public List<Transform> spawns;
  public GameObject Health;
  public GameObject PowerUp;
  public GameObject Smash;

  public bool fight = false;
  private void Awake() {
    currenctMatchTime = matchLength;

    Time.timeScale = 0;
    currentSpawnTime = SpawnTime;
    if (GameManager.player1Hero == 1) {
      Cat.GetComponent<Health>().bar = Player1StatusBar;
      Cat.GetComponent<PlayerMovement>().SetPlayer1Movement();
      Cat.GetComponent<BasicAttack>().SetPlayer1Key();
      Cat.GetComponent<RangedAttack>().SetPlayer1Key();
      Cat.GetComponent<CatUlti>().SetPlayer1Key();
      Cat.GetComponent<Health>().OnDie += EndGame;
      //Debug.Log(Cat.GetComponent<Health>().OnDie);
      GameObject go = Instantiate(Cat, Player1Spawn.transform.position, Player1Spawn.transform.rotation);
      go.GetComponentInChildren<PlayerInfo>().player = Player.PLAYER_1;
      go.GetComponentInChildren<PlayerInfo>().hero = Hero.Cat;
    } else {
      Dog.GetComponent<Health>().bar = Player1StatusBar;
      Dog.GetComponent<PlayerMovement>().SetPlayer1Movement();
      Dog.GetComponent<BasicAttack>().SetPlayer1Key();
      Dog.GetComponent<RangedAttack>().SetPlayer1Key();
      Dog.GetComponent<DogUltimate>().SetPlayer1Key();
      Dog.GetComponent<Health>().OnDie += EndGame;
      GameObject go = Instantiate(Dog, Player1Spawn.transform.position, Player1Spawn.transform.rotation);
      go.GetComponentInChildren<PlayerInfo>().player = Player.PLAYER_1;
      go.GetComponentInChildren<PlayerInfo>().hero = Hero.Dog;
    }

    if (GameManager.player2Hero == 1) {
      Cat.GetComponent<Health>().bar = Player2StatusBar;
      Cat.GetComponent<PlayerMovement>().SetPlayer2Movement();
      Cat.GetComponent<BasicAttack>().SetPlayer2Key();
      Cat.GetComponent<RangedAttack>().SetPlayer2Key();
      Cat.GetComponent<CatUlti>().SetPlayer2Key();
      Cat.GetComponent<Health>().OnDie += EndGame;
      GameObject go = Instantiate(Cat, Player2Spawn.transform.position, Player2Spawn.transform.rotation);
      go.GetComponentInChildren<PlayerInfo>().player = Player.PLAYER_2;
      go.GetComponentInChildren<PlayerInfo>().hero = Hero.Cat;

      Vector3 theScale = go.transform.localScale;
      theScale.x *= -1;
      go.transform.localScale = theScale;
      go.GetComponent<PlayerMovement>().facingRight = false;
    } else {
      Dog.GetComponent<Health>().bar = Player2StatusBar;
      Dog.GetComponent<PlayerMovement>().SetPlayer2Movement();
      Dog.GetComponent<BasicAttack>().SetPlayer2Key();
      Dog.GetComponent<RangedAttack>().SetPlayer2Key();
      Dog.GetComponent<DogUltimate>().SetPlayer2Key();
      Dog.GetComponent<Health>().OnDie += EndGame;
      GameObject go = Instantiate(Dog, Player2Spawn.transform.position, Player2Spawn.transform.rotation);
      go.GetComponentInChildren<PlayerInfo>().player = Player.PLAYER_2;
      go.GetComponentInChildren<PlayerInfo>().hero = Hero.Dog;

      Vector3 theScale = go.transform.localScale;
      theScale.x *= -1;
      go.transform.localScale = theScale;
      go.GetComponent<PlayerMovement>().facingRight = false;
      //go.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, go.GetComponent<Rigidbody2D>().velocity.y);
    }

    StartCoroutine(StartCountDown(1));

    //gameStartUI.SetActive(false);
    //Time.timeScale = 1;
  }

  private IEnumerator StartCountDown(int i) {
    yield return new WaitForSecondsRealtime(i);
    countdown.text = "2";
    Debug.Log("1_2");
    yield return new WaitForSecondsRealtime(i);
    countdown.text = "1";
    Debug.Log("1_3");
    yield return new WaitForSecondsRealtime(i);
    countdown.text = "Fight!";
    yield return new WaitForSecondsRealtime(i);

    gameStartUI.SetActive(false);
    Time.timeScale = 1;
  }

  void SpawnPowerUp() {
    List<Transform> busySpawns = new List<Transform>();
    int x = Random.Range(0, 100);

    Transform spawnPoint = null;

    while (spawnPoint == null) {
      Transform randomSpawn = spawns[Random.Range(0, spawns.Count)];
      if (randomSpawn.childCount == 0) {
        spawnPoint = randomSpawn;
      } else {
        if (!busySpawns.Contains(randomSpawn)) {
          busySpawns.Add(randomSpawn);
        }
      }

      if (busySpawns.Count == spawns.Count) {
        break;
      }

    }


    if (spawnPoint != null) {
      if (x > 25) {
        GameObject obj = Instantiate(Health, spawnPoint.position, spawnPoint.rotation);
        obj.transform.SetParent(spawnPoint);
      } else {
        GameObject obj = Instantiate(Smash, spawnPoint.position, spawnPoint.rotation);
        obj.transform.SetParent(spawnPoint);
      }
    }

    currentSpawnTime = SpawnTime;
  }

  void Update() {
    if (Time.timeScale == 1) {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
      }

      if (currenctMatchTime > 1) {
        currenctMatchTime -= Time.deltaTime;
        currentSpawnTime -= Time.deltaTime;
        var newLength = (int)currenctMatchTime;
        timer.text = "00:" + (newLength < 10 ? ("0" + newLength.ToString()) : newLength.ToString());
        if (currentSpawnTime <= 0 && currenctMatchTime > 1 && fight) {
          SpawnPowerUp();
        }
        fight = true;
      } else {
        EndGame();
      }
    }
  }

  public void EndGame() {
    Debug.Log("Game ended.");
    if (Player1StatusBar.GetCurrentFraction > Player2StatusBar.GetCurrentFraction) {
      //Player1 wins
      endGameText.text = "Player 1 WINS!";
    } else if (Player1StatusBar.GetCurrentFraction < Player2StatusBar.GetCurrentFraction) {
      //Player2 wins
      endGameText.text = "Player 2 WINS!";
    } else {
      //Draw
      endGameText.text = "DRAW!";
    }
    endgameUI.SetActive(true);
    Time.timeScale = 0;
    DisableControls();
  }

  public void DisableControls() {

  }
}
