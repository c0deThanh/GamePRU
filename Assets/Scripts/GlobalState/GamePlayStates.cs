using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class GamePlayStates
{
  private static GamePlayStates _instance;
  private GamePlayStates() { }

  public GamePlayStates Instance
  {
    get
    {
      if (_instance is null) { _instance = new GamePlayStates(); }

      return _instance;
    }
  }

  public PlayerState Player_1 { get; set; } = new PlayerState();
  public PlayerState Player_2 { get; set; } = new PlayerState();
}