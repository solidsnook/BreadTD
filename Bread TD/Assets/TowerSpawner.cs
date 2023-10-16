using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{


    public GameObject TempSpawnK;
    public GameObject TempSpawnMu;
    public GameObject TempSpawnMa;
    public GameObject LocationSpawn; 

    public void TowerPlaceK()
    {
        Vector2 Location = LocationSpawn.transform.position;
        Instantiate(TempSpawnK, Location, Quaternion.identity);
    }

    public void TowerPlaceMu()
    {
        Vector2 Location = LocationSpawn.transform.position;
        Instantiate(TempSpawnMu, Location, Quaternion.identity);
    }

    public void TowerPlaceMa()
    {
        Vector2 Location = LocationSpawn.transform.position;
        Instantiate(TempSpawnMa, Location, Quaternion.identity);
    }

}
