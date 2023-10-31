using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{


    public GameObject TempSpawnK;
    public GameObject TempSpawnMu;
    public GameObject TempSpawnMa;
    public Vector3 LocationSpawn;

    public Button KetchupSpawner;
    public Button MayoSpawner;
    public Button MustardSpawner;

    public void Start()
    {
        KetchupSpawner.onClick.AddListener(TowerPlaceK);
        MayoSpawner.onClick.AddListener(TowerPlaceMa);
        MustardSpawner.onClick.AddListener(TowerPlaceMu);
    }


    public void TowerPlaceK()
    {
        Vector3 Location = LocationSpawn;
        Instantiate(TempSpawnK, Location, Quaternion.identity);
           
    }

    public void TowerPlaceMu()
    {
        Vector3 Location = LocationSpawn;
        Instantiate(TempSpawnMu, Location, Quaternion.identity);
    }

    public void TowerPlaceMa()
    {
        Vector3 Location = LocationSpawn;
        Instantiate(TempSpawnMa, Location, Quaternion.identity);
    }

}
