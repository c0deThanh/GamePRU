using GlobalState;
using UnityEngine;

public class BulletPlayer1 : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(GamePlayStates.Instance.Player_1.SpeedBullet * transform.localScale.x, 0);
        Destroy(gameObject,2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(GamePlayStates.Instance.Player_1.Damage);
        if (collision.gameObject.tag == "Player2")
        {
            GamePlayStates.Instance.Player_2.Health -= GamePlayStates.Instance.Player_1.Damage;
            // Assuming you have a HealthBar component to update the health UI
            // FindObjectOfType<GameManager>().TakeDamageP2();


            if (GamePlayStates.Instance.Player_2.Health <= 0)
            {
                collision.gameObject.SetActive(false);
            }
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        
        
    }
}
