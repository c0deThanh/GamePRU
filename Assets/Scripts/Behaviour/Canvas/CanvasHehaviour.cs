using System.Collections;
using System.Collections.Generic;
using GlobalState;
using UnityEngine;

public class CanvasHehaviour : MonoBehaviour
{
  [SerializeField] private Transform healthBarPlayer_1;
  [SerializeField] private Transform healthBarPlayer_2;
  [SerializeField] private Transform bulletP1;
  [SerializeField] private Transform bulletP2;
  private BulletBehaviour bulletP1_b;
  private BulletBehaviour bulletP2_b;
  private HealthbarBehaviour healthP1_b;
  private HealthbarBehaviour healthP2_b;
  private GamePlayStates global = GamePlayStates.Instance;

  // Start is called before the first frame update
  void Start()
  {
    bulletP1_b = bulletP1.GetComponent<BulletBehaviour>();
    bulletP2_b = bulletP2.GetComponent<BulletBehaviour>();
    healthP1_b = healthBarPlayer_1.GetComponent<HealthbarBehaviour>();
    healthP2_b = healthBarPlayer_2.GetComponent<HealthbarBehaviour>();
  }

  // Update is called once per frame
  void Update()
  {
    Debug.Log(global.Player_1.Amount);
    bulletP1_b.SetBullet(global.Player_1.Amount, global.Player_1.AmountBullet);
    bulletP2_b.SetBullet(global.Player_2.Amount, global.Player_2.AmountBullet);
    healthP1_b.SetHealth(global.Player_1.Health, global.Player_1.MaxHealth);
    healthP2_b.SetHealth(global.Player_2.Health, global.Player_2.MaxHealth);
  }
}