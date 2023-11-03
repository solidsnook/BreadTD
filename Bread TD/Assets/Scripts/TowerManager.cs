using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject BuyScreenOBJ;

    public GameObject TempSpawnK;
    public GameObject TempSpawnMu;
    public GameObject TempSpawnMa;

    Vector2 CurrentButtonPos;

    bool Tower = false;

    public void Start()
    {
        Tower = true;
        BuyScreenOBJ.SetActive(false);

        /*
        KetchupSpawner.onClick.AddListener(TowerPlaceK());
        MayoSpawner.onClick.AddListener(TowerPlaceMa);
        MustardSpawner.onClick.AddListener(TowerPlaceMu); */ //WHYYYYY

    }

    public void TowerPlaceK()
    {
        if (Tower == true)
        {
            Instantiate(TempSpawnK, CurrentButtonPos, Quaternion.identity);

            CloseBuyScreen();
        }
    }

    public void TowerPlaceMu()
    {
        if (Tower == true)
        {
            Instantiate(TempSpawnMu, CurrentButtonPos, Quaternion.identity);

            CloseBuyScreen();
        }
    }

    public void TowerPlaceMa()
    {
        if (Tower == true)
        {
            Instantiate(TempSpawnMa, CurrentButtonPos, Quaternion.identity);

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
