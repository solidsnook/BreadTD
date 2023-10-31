using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameStarter : MonoBehaviour
{
    private GameObject MainScreen;



    // GameObject A1BuyScreen;

    void Start()
    {
        MainScreen = GameObject.Find("MainScreen");
        MainScreen.SetActive(false);
    }

}
