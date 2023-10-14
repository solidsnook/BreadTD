using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers_UI_Script : MonoBehaviour
{
    public GameObject KetchupDes;
    public GameObject MustardDes;
    public GameObject MayoDes;

    public GameObject OpenDescription;

    public void Start()
    {
        KetchupDes.SetActive(false);
        MustardDes.SetActive(false);
        MayoDes.SetActive(false);
    }

    public void KetchupDescription()
    {
        MustardDes.SetActive(true);
        OpenDescription = MustardDes;
    }

    public void MustardDescription()
    {
        KetchupDes.SetActive(true);
        OpenDescription = KetchupDes;
    }
    public void MayDescription()
    {
        MayoDes.SetActive(true);
        OpenDescription = MayoDes;
    }

    public void CloseDescription(GameObject Description)
    {
        Debug.Log("closing description");
        Description.SetActive(false);
    }
}
