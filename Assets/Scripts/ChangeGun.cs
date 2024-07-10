using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ChangeGun : MonoBehaviour
{
    public GunPoolScript gun;
    private SpriteLibrary library { get; set; }
    private List<GameObject> ImageGun { get; set; }
    private int Damage { get; set; }
    private float TimeReload { get; set; }
    private int SpeedBullet { get; set; }
    private int AmountBullet { get; set; }
    private AudioClip Reload { get; set; }
    private AudioClip Fire { get; set; }
    private string Type { get; set; }
    private List<SpriteLibraryAsset> AnimationGun;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        ImageGun=gun.ImageGun;
        AnimationGun=gun.AnimationGun;
        int index = 0;
        Transform childTransform = transform.Find("Gun");

        if (childTransform != null)
        {
            SpriteRenderer spriteRenderer = childTransform.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = ImageGun[index].GetComponent<SpriteRenderer>().sprite;
                spriteRenderer.sortingOrder= ImageGun[index].GetComponent<SpriteRenderer>().sortingOrder;
            }

            Animator ani = childTransform.GetComponent<Animator>();

            if (ani != null)
            {
                ani.runtimeAnimatorController = ImageGun[index].GetComponent<Animator>().runtimeAnimatorController;
            }

            SpriteLibrary spr = childTransform.GetComponent<SpriteLibrary>();
            if (spr != null)
            {
                spr.spriteLibraryAsset = AnimationGun[index];
                spr.RefreshSpriteResolvers();
            }

        }
        library = childTransform.GetComponent<SpriteLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        if (library != null && AnimationGun != null && AnimationGun.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log(i);
                library.spriteLibraryAsset = AnimationGun[i++];
                library.RefreshSpriteResolvers() ;
                if (i >= AnimationGun.Count)
                {
                    i = 0;
                }
            }
        }

    }
}
