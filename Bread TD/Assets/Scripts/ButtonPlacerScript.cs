using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonPlacerScript : MonoBehaviour
{
    //button stats
    private bool Ocupied;
    public GameObject OcupiedTower;


    // Start is called before the first frame update
    void Start()
    {
        Ocupied = false;
    }

    public bool IsOcupied()
    {
        return Ocupied;
    }

    public void SetOcupied(bool Set)
    {
        Ocupied = Set;
    }
}
 