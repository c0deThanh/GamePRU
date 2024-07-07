using System;
using Entity;
using GlobalState;
using UnityEngine;

namespace Behaviour.Player_2
{
  public class Player2: Player
  {
    private void Start()
    {
      Initialize();
    }
    private void Update() {  }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      OnCollisionEnterAttacked(collision, (skill, health) =>
      {
        GamePlayStates.Instance.Player_2.Health = health;
      } );
    }
  }
}