using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    GameObject MainScreen = GameObject.Find("MainScreen");
    GameObject A1BuyScreen = GameObject.Find("A1BuyScreen");


    // Start is called before the first frame update
    void Start()
    {
        A1BuyScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
