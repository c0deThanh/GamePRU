using GlobalState;
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
        if (TypePotion == "Small")
        {
            numberHeal = 20;
        }
        else
        {
            numberHeal = 50;
        }

        if (collision.gameObject.tag == "Player1")
        {
            /*            gameObject.SetActive(false);
                        var player2 = collision.gameObject.GetComponent<Player2>();
                        player2.Heal(numberHeal);
                        FindObjectOfType<GameManager>().TakeDamageP2();*/
            var _p1 = GamePlayStates.Instance.Player_1;
            _p1.Health += numberHeal;

            if (_p1.Health > _p1.MaxHealth)
            {
                _p1.Health = _p1.MaxHealth;
            }
            // Assuming you have a HealthBar component to update the health UI
            FindObjectOfType<GameManager>().TakeDamageP1();


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

        if (collision.gameObject.tag == "Player2")
        {
            var _p2 = GamePlayStates.Instance.Player_2;
            _p2.Health += numberHeal;

            if (_p2.Health > _p2.MaxHealth)
            {
                _p2.Health = _p2.MaxHealth;
            }
            // Assuming you have a HealthBar component to update the health UI
            FindObjectOfType<GameManager>().TakeDamageP2();
        }
    }
}