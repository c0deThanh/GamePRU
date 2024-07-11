using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;
using UnityEngine.U2D.Animation;
using GlobalState;
using Unity.VisualScripting;
using Behaviour.Player_1;
using Behaviour.Player_2;

public class GunPoolScript : MonoBehaviour
{
    public static GunPoolScript instance;
    public int Damage;
    public float TimeReload;
    public float TimeDelay;
    public int SpeedBullet;
    public int AmountBullet;
    public AudioClip Reload;
    public AudioClip Shoot;
    public string Type;
    public SpriteLibraryAsset AnimationGun;
    public Animator AnimationRecoil;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            gameObject.SetActive(false);
            Transform childTransform = collision.transform.Find(Type+"Point").Find(Type);
            
            if (childTransform != null)
            {
                SpriteRenderer spriteRenderer = childTransform.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
                    spriteRenderer.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
                }

                Animator ani = childTransform.GetComponent<Animator>();

                if (ani != null)
                {
                    ani.runtimeAnimatorController = AnimationRecoil.runtimeAnimatorController;
                }

                SpriteLibrary spr = childTransform.GetComponent<SpriteLibrary>();
                if (spr != null)
                {
                    spr.spriteLibraryAsset = AnimationGun;
                    spr.RefreshSpriteResolvers();
                }

            }
        }

        if (collision.gameObject.tag == "Player1")
        {
            
            //set vị trí bắn mới
            collision.gameObject.GetComponent<Player1>().shootPointPresent.SetActive(false);
            collision.gameObject.GetComponent<Player1>().shootPointPresent = collision.transform.Find(Type + "Point").gameObject;
            collision.gameObject.GetComponent<Player1>().shootPointPresent.SetActive(true);

            //set animation mới cho súng
            Animator gunAnimator = collision.gameObject.GetComponent<Player1>().animatorGun;
            gunAnimator = collision.gameObject.GetComponent<Player1>().shootPointPresent.transform.GetChild(0).GetComponent<Animator>();
            gunAnimator.runtimeAnimatorController = AnimationRecoil.runtimeAnimatorController;
            collision.gameObject.GetComponent<Player1>().animatorGun = gunAnimator;

            //Gắn âm thanh
            collision.gameObject.GetComponent<Player1>().pistolGun=Shoot;
            collision.gameObject.GetComponent<Player1>().reloadGun=Reload;

            //Setting dame bullet
            //Player1 bullet= collision.gameObject.GetComponent<Player1>();
            GamePlayStates.Instance.Player_1.Damage=Damage;
            GamePlayStates.Instance.Player_1.TimeReload = TimeReload;
            GamePlayStates.Instance.Player_1.TimeDelay = TimeDelay;
            GamePlayStates.Instance.Player_1.SpeedBullet = SpeedBullet;
            GamePlayStates.Instance.Player_1.AmountBullet = AmountBullet;
            GamePlayStates.Instance.Player_1.Amount = AmountBullet;
        }

        if (collision.gameObject.tag == "Player2")
        {
            

            //set vị trí bắn mới
            collision.gameObject.GetComponent<Player2>().shootPointPresent.SetActive(false);
            collision.gameObject.GetComponent<Player2>().shootPointPresent = collision.transform.Find(Type + "Point").gameObject;
            collision.gameObject.GetComponent<Player2>().shootPointPresent.SetActive(true);

            //set animation mới cho súng
            Animator gunAnimator = collision.gameObject.GetComponent<Player2>().animatorGun;
            gunAnimator=collision.gameObject.GetComponent<Player2>().shootPointPresent.transform.GetChild(0).GetComponent<Animator>();
            gunAnimator.runtimeAnimatorController = AnimationRecoil.runtimeAnimatorController;
            collision.gameObject.GetComponent<Player2>().animatorGun = gunAnimator;

            //Gắn âm thanh
            collision.gameObject.GetComponent<Player2>().pistolGun = Shoot;
            collision.gameObject.GetComponent<Player2>().reloadGun = Reload;

            //Setting dame bullet
            //Player1 bullet= collision.gameObject.GetComponent<Player1>();
            GamePlayStates.Instance.Player_2.Damage = Damage;
            GamePlayStates.Instance.Player_2.TimeReload = TimeReload;
            GamePlayStates.Instance.Player_2.TimeDelay = TimeDelay;
            GamePlayStates.Instance.Player_2.SpeedBullet = SpeedBullet;
            GamePlayStates.Instance.Player_2.AmountBullet = AmountBullet;
            GamePlayStates.Instance.Player_2.Amount = AmountBullet;
        }
    }

}
