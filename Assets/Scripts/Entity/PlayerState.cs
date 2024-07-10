using Helper;
using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    public class PlayerState : MonoBehaviour
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = "unknown";
        public int MaxHealth { get; set; } = 100;
        public int Health { get; set; } = 100;
        public List<Skill> Skills { get; set; } = new List<Skill>()
    {
      new Skill(){
        Cooldown = .2f,
        Name = "Punch",
        Type = Constant.DEFAULT,
        Damage = 5,
        Id = 1,
      },
    };
    }
}