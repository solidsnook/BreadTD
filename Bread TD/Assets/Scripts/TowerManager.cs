using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject BuyScreenOBJ;

    public GameObject gameManager;

    Vector2 CurrentButtonPos;

    public void Start()
    {
        BuyScreenOBJ.SetActive(false);
    }

    //function will be called by button and whatever tower is chosen and passed tp this function will be placed
    public void TowerPlace(GameObject Tower)
    {
        int cost = Tower.GetComponent<TowerScript>().cost;
        if (gameManager.GetComponent<GameManager>().RemoveCrumbs(cost))
        {
            Instantiate(Tower, CurrentButtonPos, Quaternion.identity);
            CloseBuyScreen();

        }
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
