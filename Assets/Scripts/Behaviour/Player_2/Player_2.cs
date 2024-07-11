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
    public Animator animatorGun { set; get; }
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
    public GameObject bullet;
    [SerializeField]
    GameObject bulletEffect;
    [SerializeField]
    GameObject ShootPoint;

    public KeyCode left1 = KeyCode.LeftArrow;
    public KeyCode right1 = KeyCode.RightArrow;
    public KeyCode jump1 = KeyCode.UpArrow;
    public KeyCode pickUp1;
    public KeyCode attack1 = KeyCode.Return;

    AudioSource soundGun;
    public AudioClip pistolGun;
    public AudioClip reloadGun;
    

    public GameObject shootPointPresent { set; get; }
        float timer=0;
    private void Start()
    {
      Initialize();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        soundGun=GetComponent<AudioSource>();
        animator.SetLayerWeight(animator.GetLayerIndex("Player2"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("Player1"), 0);
        animatorGun = ShootPoint.transform.GetChild(0).GetComponent<Animator>();
       //ShootPoint.GetChild(0).GetComponent<GameObject>().transform.localScale= new Vector3(-1,1,1);
       shootPointPresent =ShootPoint;  
       

            
    }
    private void Update() {
            timer += Time.deltaTime;
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
            if (Input.GetKeyDown(attack1) && timer >= GamePlayStates.Instance.Player_2.TimeDelay && GamePlayStates.Instance.Player_2.Amount > 0)
            {
                timer = 0;
                animatorGun.SetTrigger("Shoot");
                GamePlayStates.Instance.Player_2.Amount -= 1;
                //Debug.Log(GamePlayStates.Instance.Player_2.Amount);
                GameObject bulletEffectClone = Instantiate(bulletEffect, shootPointPresent.transform.position, shootPointPresent.transform.rotation);

                //set dame bullet
                GameObject bulletClone = Instantiate(bullet, shootPointPresent.transform.position, shootPointPresent.transform.rotation);

                soundGun.PlayOneShot(pistolGun);
                bulletClone.transform.localScale = transform.localScale * 0.2f*-1;
                bulletEffectClone.transform.localScale = transform.localScale * 0.02f;
                bulletEffectClone.transform.position = new Vector3(shootPointPresent.transform.position.x, shootPointPresent.transform.position.y, shootPointPresent.transform.position.z);
                Destroy(bulletEffectClone, 0.05f);
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