using Behaviour;
using Behaviour.Player_1;
using Behaviour.Player_2;
using Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    [SerializeField]
    private string TypePotion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int numberHeal = 0;
        if(TypePotion == "Small")
        {
            numberHeal = 20;
        }
        else
        {
            numberHeal = 50;
        }

        if (collision.gameObject.tag == "Player2")
        {
            gameObject.SetActive(false);
            var player2 = collision.gameObject.GetComponent<Player2>();
            var player = player2.GetComponent<Player>();
            player.Heal(numberHeal);

            //var curet = player._state.Health;
            //if (x._state.Health < 100)
            //{
            //    x._state.Health = x._state.Health + numberHeal;
            //    if(x._state.Health > 100)
            //    {
            //        x._state.Health = 100;
            //    }
            //}

            //hinh anh
            //var healthCurrent  = GamePlayStates.Instance.Player_1.Health;
            //if (healthCurrent < 100)
            //{
            //    GamePlayStates.Instance.Player_1.Health = healthCurrent + numberHeal;
            //    if(GamePlayStates.Instance.Player_1.Health > 100)
            //    {
            //        GamePlayStates.Instance.Player_1.Health = 100;
            //    }
            //}
        }
    }
}