using System;
using System.Linq;
using Entity;
using GlobalState;
using UnityEngine;

namespace Behaviour.Player_1
{
  public class Player1: Player
  {
    private void Start()
    {
      Initialize();
      Debug.Log(GamePlayStates.Instance.Player_1.Skills.FirstOrDefault()?.Name);
    }
    private void Update() {  }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      OnCollisionEnterAttacked(collision, (skill, health) =>
      {
        GamePlayStates.Instance.Player_1.Health = health;
      } );
    }
  }
}