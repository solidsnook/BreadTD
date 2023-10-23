using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    public GameObject BuyScreenOBJ;
    public GameObject CavasOBJ;
    public Button A1;

    public GameObject empty;

    public TowerSpawner spawnCS;
    public Vector3 LocalPos;


    public void Start()
    {

        A1.onClick.AddListener(BuyScreenSpawn);
        LocalPos = A1.GetComponentInChildren<GameObject>().transform.position;
        spawnCS.LocationSpawn = LocalPos;
    }

    public void BuyScreenSpawn()
    {
        empty = Instantiate(BuyScreenOBJ, new Vector3(0, 0, 0), Quaternion.identity);
        empty.transform.SetParent(CavasOBJ.transform, false);
    }


}



//A1.GetComponent<GameObject>;
//Instantiate(BuyScreenOBJ, CavasOBJ, new Vector3(0, 0, 0), Quaternion.identity);
