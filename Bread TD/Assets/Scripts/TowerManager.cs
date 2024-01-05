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

    public Sprite NotOccupied, Occupied;

    public GameObject SellScreenOBJ;

    public GameObject spawnedTower;


    public void Start()
    {
        BuyScreenOBJ.SetActive(false);
        SellScreenOBJ.SetActive(false);

        if (SelectedButton != null)
        {
            SelectedButton.GetComponent<Image>().sprite = NotOccupied;
        }
    }

    //function will be called by button and whatever tower is chosen and passed to this function will be placed
    public void TowerPlace(GameObject Tower)
    {
        //check if selected button is ocupied
        if (SelectedButton.GetComponent<ButtonPlacerScript>().IsOcupied())
        {
            Debug.Log("Cant PLace Tower Here Alrready Has Tower Placed");

            return;
        }

        //place tower if not rocupied and reduce crumb count
        int cost = Tower.GetComponent<TowerScript>().cost;

        if (gameManager.GetComponent<GameManager>().RemoveCrumbs(cost))
        {
            GameObject NewTower = Instantiate(Tower, SelectedButton.transform.position, Quaternion.identity);

            SelectedButton.GetComponent<ButtonPlacerScript>().SetOcupied(true);
            SelectedButton.GetComponent<ButtonPlacerScript>().OcupiedTower = NewTower;
            SelectedButton.GetComponent<Image>().sprite = Occupied;
            Debug.Log("Tower Placed");

            //add tower placed to player stats
            PlayerPrefs.SetInt("TowersPlaced", PlayerPrefs.GetInt("TowersPlaced") + 1);

            CloseBuyScreen();
            return;
        }
    }


    public void OpenScreenChecker(GameObject Button)
    {
        SelectedButton = Button;

        //if (SelectedButton == Occupied)
        if (SelectedButton.GetComponent<ButtonPlacerScript>().IsOcupied() == false)
        {
            OpenBuyScreen(SelectedButton);
        }
        if (SelectedButton.GetComponent<ButtonPlacerScript>().IsOcupied() == true)
        {
            OpenSellScreen(SelectedButton);
        }
    }

    public void OpenBuyScreen(GameObject Button)
    {
        BuyScreenOBJ.SetActive(true);

        SelectedButton = Button;
    }

    public void CloseBuyScreen()
    {
        BuyScreenOBJ.SetActive(false);
    }


    public void OpenSellScreen(GameObject Button)
    {
        SellScreenOBJ.SetActive(true);

        SelectedButton = Button;
    }

    public void CloseSellScreen()
    {
        SellScreenOBJ.SetActive(false);
    }


    public void TowerSale() 
    {
        //set ocupied to false
        SelectedButton.GetComponent<ButtonPlacerScript>().SetOcupied(false);
        SelectedButton.GetComponent<Image>().sprite = NotOccupied;
        GameObject RefundTower = SelectedButton.GetComponent<ButtonPlacerScript>().OcupiedTower;
        SelectedButton.GetComponent<ButtonPlacerScript>().OcupiedTower = null;

        //add crumbs
        int RefundAmount = RefundTower.GetComponent<TowerScript>().sellValue;
        gameManager.GetComponent<GameManager>().AddCrumbs(RefundAmount);
        Debug.Log("Tower Sold");

        //delete tower
        Destroy(RefundTower);

        return;
    }

}
