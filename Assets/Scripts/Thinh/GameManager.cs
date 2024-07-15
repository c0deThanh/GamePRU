using GlobalState;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player1;
    [SerializeField]
    HealthBar p1HealthBar;

    [SerializeField]
    GameObject player2;
    [SerializeField]
    HealthBar p2HealthBar;

    [SerializeField]
    AudioClip backGround;
    AudioSource managerSound;


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Canvas", LoadSceneMode.Additive);
        if (GamePlayStates.Instance.Player_1.Health == 0)
        {
            GamePlayStates.Instance.Player_1.Health = GamePlayStates.Instance.Player_1.MaxHealth;
        }
        p1HealthBar.SetMaxHealth(GamePlayStates.Instance.Player_1.MaxHealth);
        p1HealthBar.SetHealth(GamePlayStates.Instance.Player_1.Health);


        // Initialize player 2 health
        GamePlayStates.Instance.Player_2.MaxHealth = 100; // Assuming max health is 100
        if (GamePlayStates.Instance.Player_2.Health == 0)
        {
            GamePlayStates.Instance.Player_2.Health = GamePlayStates.Instance.Player_2.MaxHealth;
        }
        p2HealthBar.SetMaxHealth(GamePlayStates.Instance.Player_2.MaxHealth);
        p2HealthBar.SetHealth(GamePlayStates.Instance.Player_2.Health);

        managerSound = GetComponent<AudioSource>();
        managerSound.PlayOneShot(backGround);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamageP1()
    {
        p1HealthBar.SetHealth(GamePlayStates.Instance.Player_1.Health);
        if (GamePlayStates.Instance.Player_1.Health <= 0)
        {
            player1.SetActive(false);
        }
    }

    public void TakeDamageP2()
    {
        p2HealthBar.SetHealth(GamePlayStates.Instance.Player_2.Health);
        if (GamePlayStates.Instance.Player_2.Health <= 0)
        {
            player2.SetActive(false);
        }
    }

}
