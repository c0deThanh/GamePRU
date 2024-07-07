using System.Collections.Generic;
using Helper;
using UnityEngine;

namespace Entity
{
  public class PlayerState
  {
    public int Id { get; set; }
    public string PlayerName { get; set; } = "unknown";
    public int Health { get; set; } = 100;
    public List<Skill> Skills { get; set; } = new()
    {
      new Skill{
        Cooldown = .2f,
        Name = "Punch",
        Type = Constant.DEFAULT,
        Damage = 5,
        Id = 1,
      },
    };
  }
}