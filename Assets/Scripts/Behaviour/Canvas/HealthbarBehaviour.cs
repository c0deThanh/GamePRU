using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
  [SerializeField] private Slider slider;
  [SerializeField] private Color32 high = new Color32(255,104,98, 255);
  [SerializeField] private Color32 low = new Color32(130,179,102,255);
  private Vector3 _offset;
  private float _currentHealth;
  void Start() { }

  public void SetHealth(float currentHealth, float maxHealth)
  {
    _currentHealth = currentHealth;
    slider.gameObject.SetActive(currentHealth <= maxHealth);
    slider.value = currentHealth;
    slider.maxValue = maxHealth;
    // var co = Color.red;
    slider.fillRect.GetComponentInChildren<Image>().color =
      Color.Lerp(high,low ,  slider.normalizedValue);
    // Debug.Log("");
  }

  // Update is called once per frame
  void Update()
  {
    
    // if (_currentHealth <= 0) { Destroy(gameObject); }
    // slider.transform.position = Camera.main!.WorldToScreenPoint(transform.parent.position + _offset);
  }
}