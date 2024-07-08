using UnityEngine;

namespace Entity
{
  public class Skill: MonoBehaviour
  {
    public Skill(){}
    public string Name { get; set; }
    public int Damage { get; set; }
    public float Cooldown { get; set; }
    public int Id { get; set; }
    public int Type { get; set; }
  }
}