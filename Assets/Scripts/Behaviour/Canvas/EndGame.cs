using System.Collections;
using System.Collections.Generic;
using GlobalState;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
  [SerializeField] private Text text;

  // Start is called before the first frame update
  void Start()
  {
    var gamePlayStates = GamePlayStates.Instance;
    if (gamePlayStates.Player_2.Health <= 0 && gamePlayStates.Player_2.Health < gamePlayStates.Player_1.Health)
    {
      gamePlayStates.Player_1.Score += 1;
      text.text = "Player 1 wins(" + gamePlayStates.Player_1.Score + ":" + gamePlayStates.Player_2.Score + ")";
    }
    else
      if (gamePlayStates.Player_1.Health <= 0 && gamePlayStates.Player_1.Health < gamePlayStates.Player_2.Health)
      {
        gamePlayStates.Player_2.Score += 1;
        text.text = "Player 2 wins(" + gamePlayStates.Player_2.Score + ":" + gamePlayStates.Player_1.Score + ")";
      }
      else { text.text = "Draw"; }

    gamePlayStates.Player_2.Health = gamePlayStates.Player_2.MaxHealth;
    gamePlayStates.Player_1.Health = gamePlayStates.Player_1.MaxHealth;
  }

  // Update is called once per frame
  void Update() { }

  public void returnHome()
  {
        Time.timeScale = 1;
    SceneManager.LoadScene("MainGameScene");
  }
}