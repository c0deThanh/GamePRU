using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using GlobalState;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour.Player_1
{
  public class Player1: Player
  {
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 15f;
    Rigidbody2D rigid;
    Animator animator;
    Animator animatorGun;
    private bool facingRight = true;

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
    GameObject bulletEffect;
    [SerializeField]
    Transform ShootPoint;

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.W;
    public KeyCode pickUp;
    public KeyCode attack = KeyCode.Return;
    AudioSource soundGun;
    public AudioClip pistolGun;

    
    private void Start()
    {
      Initialize();
      rigid = GetComponent<Rigidbody2D>();
      animator=GetComponent<Animator>();
      soundGun=GetComponent<AudioSource>();
      animatorGun=ShootPoint.GetChild(0).GetComponent<Animator>();
      //Debug.Log(GamePlayStates.Instance.Player_1.Skills.FirstOrDefault()?.Name);

    }
    private void Update() {
            isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
            isMove = Input.GetAxisRaw("Horizontal");
            // Move right
            if (Input.GetKey(right))
            {
                rigid.velocity= new Vector2(speed,rigid.velocity.y);

                if (!facingRight)
                {
                    Flip();
                }
            }

            // Move left
            if (Input.GetKey(left))
            {
                rigid.velocity = new Vector2(-speed, rigid.velocity.y);

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
            if (Input.GetKeyDown(attack))
            {
                animatorGun.SetTrigger("Shoot");
                GameObject bulletClone = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
                GameObject bulletEffectClone = Instantiate(bulletEffect, ShootPoint.position, ShootPoint.rotation);
                soundGun.PlayOneShot(pistolGun);
                bulletClone.transform.localScale = transform.localScale * 0.2f;
                bulletEffectClone.transform.localScale = transform.localScale * 0.02f;
                bulletEffectClone.transform.position = new Vector3(ShootPoint.position.x, ShootPoint.position.y, ShootPoint.position.z);
                Destroy(bulletEffectClone,0.05f);

            }

            animator.SetFloat("Run", Math.Abs(rigid.velocity.x));
            animator.SetBool("isJumping", !isGrounded);
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      OnCollisionEnterAttacked(collision, (skill, health) =>
      {
        GamePlayStates.Instance.Player_1.Health = health;
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