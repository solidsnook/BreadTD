using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//needs a destroy added for buy screen and fix the double call of each tower

public class TowerSpawner : MonoBehaviour
{


    public GameObject TempSpawnK;
    public GameObject TempSpawnMu;
    public GameObject TempSpawnMa;
    public Vector3 LocationSpawn;
      
    public Button KetchupSpawner;
    public Button MayoSpawner;
    public Button MustardSpawner;

    public ButtonControl BuyCS;


    bool Tower = false;

    public void Start()
    {
        Tower = true;
        KetchupSpawner.onClick.AddListener(TowerPlaceK);
        MayoSpawner.onClick.AddListener(TowerPlaceMa);
        MustardSpawner.onClick.AddListener(TowerPlaceMu);

    }


    public void TowerPlaceK()
    {
        if (Tower == true)
        {
            Instantiate(TempSpawnK, LocationSpawn, Quaternion.identity);
        Tower = false;
        }
    }

    public void TowerPlaceMu()
    {
        if (Tower == true)
        {
            Instantiate(TempSpawnMu, LocationSpawn, Quaternion.identity);

            Tower = false;
        }
    }

    public void TowerPlaceMa()
    {

        if (Tower == true)
        {
            Instantiate(TempSpawnMa, LocationSpawn, Quaternion.identity);

            Tower = false;
        }



    }

 

}
