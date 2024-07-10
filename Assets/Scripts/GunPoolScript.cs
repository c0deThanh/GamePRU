using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;
using UnityEngine.U2D.Animation;

public class GunPoolScript : MonoBehaviour
{
    public static GunPoolScript instance;
    public List<GameObject> ImageGun;
    public int Damage;
    public float TimeReload;
    public int SpeedBullet;
    public int AmountBullet;
    public AudioClip Reload;
    public AudioClip Fire;
    public string Type;
    public List<SpriteLibraryAsset> AnimationGun;


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


}
