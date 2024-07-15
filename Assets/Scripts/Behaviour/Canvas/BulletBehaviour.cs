using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{
  [SerializeField] private Slider slider;
  [SerializeField] private Color32 high = new Color32(255,104,98, 255);
  [SerializeField] private Color32 low = new Color32(130,179,102,255);
  private Vector3 _offset;
  private float _currenBulet;
  void Start() { }

  public void SetBullet(float currentBullet, float max)
  {
    _currenBulet = currentBullet;
    slider.gameObject.SetActive(currentBullet <= max);
    slider.value = currentBullet;
    slider.maxValue = max;
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