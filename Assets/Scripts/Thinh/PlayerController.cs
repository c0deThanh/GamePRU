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
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform ShootPoint;

    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
    public KeyCode jump = KeyCode.UpArrow;
    public KeyCode pickUp;
    public KeyCode attack = KeyCode.Space;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        // Move right
        if (Input.GetKey(right))
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
        if (Input.GetKey(left))
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


        // Jump
        if (isGrounded && Input.GetKey(jump))
        {
            rigid.velocity = Vector2.up * jumpForce;
        }

        // Attack
        if (Input.GetKey(attack))
        {
            GameObject bulletClone = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
            bulletClone.transform.localScale = transform.localScale;
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
