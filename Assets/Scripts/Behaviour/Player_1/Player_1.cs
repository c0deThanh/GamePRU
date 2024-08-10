using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using GlobalState;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour.Player_1
{
    public class Player1 : Player
    {
        [SerializeField]
        float speed = 5f;
        [SerializeField]
        float jumpForce = 15f;
        Rigidbody2D rigid;
        Animator animator;
        public Animator animatorGun { set; get; }
        private bool facingRight = true;

        [SerializeField]
        LayerMask groundLayer;
        private bool isGrounded;
        private float isMove;

        [SerializeField]
        Transform feetPosition;
        [SerializeField]
        float groundCheckCircle;
        public GameObject bullet;
        [SerializeField]
        GameObject bulletEffect;
        [SerializeField]
        GameObject ShootPoint;

        public KeyCode left = KeyCode.A;
        public KeyCode right = KeyCode.D;
        public KeyCode jump = KeyCode.W;
        public KeyCode pickUp;
        public KeyCode attack = KeyCode.Return;
        AudioSource soundGun;
        public AudioClip pistolGun;
        public AudioClip reloadGun;
        AudioManager audioManager;

        public GameObject shootPointPresent { set; get; }
        float timer=0;
    
    private void Start()
    {
      Initialize();
      rigid = GetComponent<Rigidbody2D>();
      animator=GetComponent<Animator>();
      soundGun=GetComponent<AudioSource>();
      animatorGun = ShootPoint.transform.GetChild(0).GetComponent<Animator>();
      //Debug.Log(GamePlayStates.Instance.Player_1.Skills.FirstOrDefault()?.Name);
      shootPointPresent=ShootPoint;

    }
        public void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        }
        private void Update() {
            timer += Time.deltaTime;
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
            if (Input.GetKey(attack) && timer >= GamePlayStates.Instance.Player_1.TimeDelay && GamePlayStates.Instance.Player_1.Amount>0)
            {
                timer = 0;
                animatorGun.SetTrigger("Shoot");

                GamePlayStates.Instance.Player_1.Amount -= 1;
                //Debug.Log(GamePlayStates.Instance.Player_1.Amount);
                //set dame bullet
                GameObject bulletClone = Instantiate(bullet, shootPointPresent.transform.position, shootPointPresent.transform.rotation);

                GameObject bulletEffectClone = Instantiate(bulletEffect, shootPointPresent.transform.position, shootPointPresent.transform.rotation);
                //soundGun.PlayOneShot(pistolGun);
                audioManager.PlaySFX(pistolGun);
                bulletClone.transform.localScale = transform.localScale * 0.2f;
                bulletEffectClone.transform.localScale = transform.localScale * 0.02f;
                bulletEffectClone.transform.position = new Vector3(shootPointPresent.transform.position.x, shootPointPresent.transform.position.y, shootPointPresent.transform.position.z);
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