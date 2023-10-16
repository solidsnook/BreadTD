using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject TowersMenu;
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    public void TowerMenu()
    {
        TowersMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void SettingMenu()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void QuitApplication() 
    {
        Application.Quit();
    }
}
