using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 10f;
    [SerializeField]
    Rigidbody2D rigid;
    private bool facingRight = true;

    [SerializeField]
    LayerMask groundLayer;
    private bool isGrounded;
    [SerializeField]
    Transform feetPosition;
    [SerializeField]
    float groundCheckCircle;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(
                transform.position.x + speed * Time.deltaTime,
                transform.position.y,
                transform.position.z);

            if (!facingRight)
            {
                Flip();
            }
        }

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(
                transform.position.x - speed * Time.deltaTime,
                transform.position.y,
                transform.position.z);

            if (facingRight)
            {
                Flip();
            }
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        // Jump
        if (isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            rigid.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
