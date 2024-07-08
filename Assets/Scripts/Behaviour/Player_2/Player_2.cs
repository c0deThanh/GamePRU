using System;
using Entity;
using GlobalState;
using UnityEngine;

namespace Behaviour.Player_2
{
  public class Player2: Player
  {
        [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 10f;
    Rigidbody2D rigid;
    Animator animator;
    private bool facingRight = false;

    [SerializeField]
    LayerMask groundLayer;
    private bool isGrounded;
    private float isMove;

    [SerializeField]
    Transform feetPosition;
    [SerializeField]
    float groundCheckCircle;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform ShootPoint;

    public KeyCode left1 = KeyCode.LeftArrow;
    public KeyCode right1 = KeyCode.RightArrow;
    public KeyCode jump1 = KeyCode.UpArrow;
    public KeyCode pickUp1;
    public KeyCode attack1 = KeyCode.Return;
    private void Start()
    {
      Initialize();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetLayerWeight(animator.GetLayerIndex("Player2"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("Player1"), 0);
            
            
        }
    private void Update() {
            isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
            isMove = Input.GetAxisRaw("Horizontal");
            // Move right
            if (Input.GetKey(right1))
            {
                rigid.velocity = new Vector2(speed, rigid.velocity.y);

                if (!facingRight)
                {
                    Flip();
                }
            }

            // Move left
            if (Input.GetKey(left1))
            {
                rigid.velocity = new Vector2(-speed, rigid.velocity.y);

                if (facingRight)
                {
                    Flip();
                }
            }


            // Jump
            if (isGrounded && Input.GetKey(jump1))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }

            // Attack
            if (Input.GetKeyDown(attack1))
            {
                GameObject bulletClone = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
                int i = -1;
                if (facingRight) { i = 1; }
                bulletClone.transform.localScale = transform.localScale * 0.1f*i;
            }

            animator.SetFloat("Run1", Math.Abs(rigid.velocity.x));
            animator.SetBool("isJumping1", !isGrounded);
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      OnCollisionEnterAttacked(collision, (skill, health) =>
      {
        GamePlayStates.Instance.Player_2.Health = health;
      } );
    }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(feetPosition.transform.position, groundCheckCircle);
        }
        void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    }
}