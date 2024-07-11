using Behaviour.Player_1;
using Behaviour.Player_2;
using GlobalState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class BulletScript : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Player1")
        {
            Destroy(gameObject);
            GamePlayStates.Instance.Player_1.Amount = GamePlayStates.Instance.Player_1.AmountBullet;
            //Debug.Log(GamePlayStates.Instance.Player_1.Amount);
        }
        if (collision.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
            GamePlayStates.Instance.Player_2.Amount = GamePlayStates.Instance.Player_2.AmountBullet;
            //Debug.Log(GamePlayStates.Instance.Player_1.Amount);
        }
    }
}
