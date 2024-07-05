using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slHealth;
    [SerializeField]
    Gradient gdHealth;
    [SerializeField]
    Image imgFill;
    // Start is called before the first frame update
    public void SetHealth(int health)
    {
        slHealth.value = health;
        imgFill.color = gdHealth.Evaluate(slHealth.normalizedValue);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slHealth.maxValue = maxHealth;
        slHealth.value = maxHealth;

        imgFill.color = gdHealth.Evaluate(1f);
    }
}
