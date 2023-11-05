using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject BuyScreenOBJ;

    GameManager gameManager;

    Vector2 CurrentButtonPos;

    bool Tower = false;

    public void Start()
    {
        BuyScreenOBJ.SetActive(false);
    }

    //function will be called by button and whatever tower is chosen and passed tp this function will be placed
    public void TowerPlace(GameObject Tower)
    {
        //if(gameManager.GetComponent<GameManager>().RemoveCrumbs())
        Instantiate(Tower, CurrentButtonPos, Quaternion.identity);
        CloseBuyScreen();
    }

    public void OpenBuyScreen(GameObject Button)
    {
        BuyScreenOBJ.SetActive(true);

        CurrentButtonPos = Button.transform.position;
    }

    public void CloseBuyScreen()
    {
        BuyScreenOBJ.SetActive(false);
    }
}
