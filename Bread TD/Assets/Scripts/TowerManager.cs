using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public GameObject BuyScreenOBJ;

    public GameObject gameManager;

    [SerializeField]
    GameObject SelectedButton;

    Vector2 CurrentButtonPos;

    public Sprite NotOccupied, Occupied;

    public void Start()
    {
        BuyScreenOBJ.SetActive(false);

        if (SelectedButton != null)
        {
            SelectedButton.GetComponent<Image>().sprite = NotOccupied;
        }
    }

    //function will be called by button and whatever tower is chosen and passed tp this function will be placed
    public void TowerPlace(GameObject Tower)
    {
        if (SelectedButton.GetComponent<ButtonPlacerScript>().IsOcupied())
        {
            Debug.Log("Cant PLace Tower Here Alrready Has Tower Placed");
            return;
        }

        int cost = Tower.GetComponent<TowerScript>().cost;
        if (gameManager.GetComponent<GameManager>().RemoveCrumbs(cost))
        {
            Instantiate(Tower, CurrentButtonPos, Quaternion.identity);
            SelectedButton.GetComponent<ButtonPlacerScript>().SetOcupied(true);

            if (SelectedButton.GetComponent<ButtonPlacerScript>().GetOcupied() == true) {
            SelectedButton.GetComponent<Image>().sprite = Occupied;
                Debug.Log("button sprite change");

            }
            CloseBuyScreen();
        }
    }

    public void OpenBuyScreen(GameObject Button)
    {
        BuyScreenOBJ.SetActive(true);

        SelectedButton = Button;
        CurrentButtonPos = SelectedButton.transform.position;
    }

    public void CloseBuyScreen()
    {
        BuyScreenOBJ.SetActive(false);
    }
}
