using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers_UI_Script : MonoBehaviour
{
    public GameObject TowersMenu;
    public GameObject MainMenu;

    public GameObject KetchupDes;
    public GameObject MustardDes;
    public GameObject MayoDes;

    public void Start()
    {
        KetchupDes.SetActive(false);
        MustardDes.SetActive(false);
        MayoDes.SetActive(false);
    }

    public void BackToMenu()
    {
        TowersMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void KetchupDescription()
    {
        MustardDes.SetActive(true);
    }

    public void MustardDescription()
    {
        KetchupDes.SetActive(true);
    }
    public void MayDescription()
    {
        MayoDes.SetActive(true);
    }

    public void CloseDescription(GameObject Description)
    {
        Debug.Log("closing description");
        Description.SetActive(false);
    }
}
