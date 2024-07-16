using GlobalState;
using UnityEngine;

public class BulletPlayer2 : MonoBehaviour
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
        rigid.velocity = new Vector2(GamePlayStates.Instance.Player_2.SpeedBullet * transform.localScale.x, 0);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(GamePlayStates.Instance.Player_2.Damage);
        if (collision.gameObject.tag == "Player1")
        {
            GamePlayStates.Instance.Player_1.Health -= GamePlayStates.Instance.Player_2.Damage;
            // Assuming you have a HealthBar component to update the health UI
            FindObjectOfType<GameManager>().TakeDamageP1();


            if (GamePlayStates.Instance.Player_1.Health <= 0)
            {
                collision.gameObject.SetActive(false);
            }
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        
        
    }
}
