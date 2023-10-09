using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject TowersMenu;
    public GameObject MainMenu;

    public void TowerButton()
    {
        TowersMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
