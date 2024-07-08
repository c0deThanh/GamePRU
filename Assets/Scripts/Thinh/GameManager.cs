using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player1;
    [SerializeField]
    HealthBar p1HealthBar;
    [SerializeField]
    int p1MaxHealth = 100;
    int p1Health;

    [SerializeField]
    GameObject player2;
    [SerializeField]
    HealthBar p2HealthBar;
    [SerializeField]
    int p2MaxHealth = 100;
    int p2Health;

    [SerializeField]
    AudioClip backGround;
    AudioSource managerSound;


    // Start is called before the first frame update
    void Start()
    {
        p1Health = p1MaxHealth;
        p1HealthBar.SetMaxHealth(p1MaxHealth);

        p2Health = p2MaxHealth;
        p2HealthBar.SetMaxHealth(p2MaxHealth);

        managerSound=GetComponent<AudioSource>();
        managerSound.PlayOneShot(backGround);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamageP1(int damage)
    {
        p1Health -= damage;
        p1HealthBar.SetHealth(p1Health);
        if (p1Health <= 0)
        {
            player1.SetActive(false);
        }
    }
    public void TakeDamageP2(int damage)
    {
        p2Health -= damage;
        p2HealthBar.SetHealth(p2Health);
        if (p2Health <= 0)
        {
            player2.SetActive(false);
        }
    }

}
