using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private GameObject MainScreen;
    private GameObject A1BuyScreen;


    // GameObject A1BuyScreen;

    void Start()
    {

        MainScreen = GameObject.Find("MainScreen");
        A1BuyScreen = GameObject.Find("A1BuyScreen");
        A1BuyScreen.SetActive(false);
        MainScreen.SetActive(false);
    }
}
