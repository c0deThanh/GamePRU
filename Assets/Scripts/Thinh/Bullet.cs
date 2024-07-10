using GlobalState;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    GameObject effect;
    [SerializeField]
    int damage;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            GamePlayStates.Instance.Player_1.Health -= damage;
            // Assuming you have a HealthBar component to update the health UI
            FindObjectOfType<GameManager>().TakeDamageP1();


            if (GamePlayStates.Instance.Player_1.Health <= 0)
            {
                collision.gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.tag == "Player2")
        {
            GamePlayStates.Instance.Player_2.Health -= damage;
            // Assuming you have a HealthBar component to update the health UI
            FindObjectOfType<GameManager>().TakeDamageP2();


            if (GamePlayStates.Instance.Player_2.Health <= 0)
            {
                collision.gameObject.SetActive(false);
            }
        }

        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
