using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
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

    public GameObject eggBomb;

    public Transform targetPoint;

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
        GameObject KetchBuyText = GameObject.Find("BuyScreen/Panel/Ketchup/Ketchup Cost");
        GameObject MustBuyText = GameObject.Find("BuyScreen/Panel/Mustard/MustardCost");
        GameObject MayoBuyText = GameObject.Find("BuyScreen/Panel/Mayo/Mayo Cost");

        KetchBuyText.GetComponent<TextMeshProUGUI>().text = "Value: 50 Crumbs";
        MustBuyText.GetComponent<TextMeshProUGUI>().text = "Value: 75 Crumbs";
        MayoBuyText.GetComponent<TextMeshProUGUI>().text = "Value: 115 Crumbs";

        SelectedButton = Button;


    }

    public void CloseBuyScreen()
    {
        BuyScreenOBJ.SetActive(false);
    }


    public void OpenSellScreen(GameObject Button)
    {
        SellScreenOBJ.SetActive(true);
        GameObject SellImage = GameObject.Find("Sell Screen/Panel/Tower IMG");
        GameObject SellText = GameObject.Find("Sell Screen/Panel/Value Text");
        GameObject Tower = Button.GetComponentInChildren<ButtonPlacerScript>().OcupiedTower;

        SellImage.GetComponent<Image>().sprite = Button.GetComponentInChildren<ButtonPlacerScript>().OcupiedTower.GetComponentInChildren<SpriteRenderer>().sprite;

        SellText.GetComponent<TextMeshProUGUI>().text = "Value: " + Tower.GetComponent<TowerScript>().sellValue + " Crumbs";
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

    public void EggPlace()
    {
        // Finds every enemy currently in the level
        GameObject[] breads = GameObject.FindGameObjectsWithTag("Enemy");

        // If any enemies exist then execute code
        if (breads.Length > 0)
        {
            // Creating variables
            GameObject closestBread = null;
            float minDist = Mathf.Infinity;
            int cost = eggBomb.GetComponent<EggBombScript>().cost;

            if (gameManager.GetComponent<GameManager>().RemoveCrumbs(cost))
            {
                // For each bread in the scene check the distance between the bread and the target point. 
                // If the distance is less than the minimum distance then minimum distance is set to the new smaller distance
                foreach (GameObject bread in breads)
                {
                    float distance = Vector3.Distance(bread.transform.position, targetPoint.position);

                    if (distance < minDist)
                    {
                        minDist = distance;
                        closestBread = bread;
                    }
                }

                // If the closest bread was found then place egg bomb on its position
                if (closestBread != null)
                {
                    Instantiate(eggBomb, closestBread.transform.position, Quaternion.identity);
                }
            }  
        }
    }

}
