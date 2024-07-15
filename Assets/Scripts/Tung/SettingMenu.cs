using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] GameObject settingMenu;
    public void Setting_OnClick()
    {
        settingMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Setting_Off()
    {
        settingMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
