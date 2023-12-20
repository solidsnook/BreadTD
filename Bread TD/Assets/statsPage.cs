using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class statsPage : MonoBehaviour
{
    public GameObject breadsDestroyedTxt;
    public GameObject CrumbsSpentTxt;
    public GameObject TowersPlacedTxt;
    public GameObject LifeLostTxt;
    public GameObject TimePlayedTxt;
    public GameObject LevelsCompletedTxt;

    public GameObject SettingsPage;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BreadsDestroyed") == false) PlayerPrefs.SetInt("BreadsDestroyed", 0);
        if (PlayerPrefs.HasKey("crumbsSpent") == false) PlayerPrefs.SetInt("crumbsSpent", 0);
        if (PlayerPrefs.HasKey("TowersPlaced") == false) PlayerPrefs.SetInt("TowersPlaced", 0);
        if (PlayerPrefs.HasKey("LifeLost") == false) PlayerPrefs.SetInt("LifeLost", 0);
        if (PlayerPrefs.HasKey("TimePlayed") == false) PlayerPrefs.SetInt("TimePlayed", 0);
        if (PlayerPrefs.HasKey("LevelsCompleted") == false) PlayerPrefs.SetInt("LevelsCompleted", 0);
    }

    public void InitiateStats()
    {
        this.gameObject.SetActive(true);
        SettingsPage.SetActive(false);

        //initate all stats variables
        breadsDestroyedTxt.GetComponent<TextMeshProUGUI>().text = "Breads Destroyed: " + PlayerPrefs.GetInt("BreadsDestroyed");
        CrumbsSpentTxt.GetComponent<TextMeshProUGUI>().text = "Crumbs Spent: " + PlayerPrefs.GetInt("CrumbsSpent");
        TowersPlacedTxt.GetComponent<TextMeshProUGUI>().text = "Towers Placed: " + PlayerPrefs.GetInt("TowersPlaced");
        LifeLostTxt.GetComponent<TextMeshProUGUI>().text = "Life Lost: " + PlayerPrefs.GetInt("LifeLost");
        TimePlayedTxt.GetComponent<TextMeshProUGUI>().text = "Time Played: " + PlayerPrefs.GetInt("TimePlayed");
        LevelsCompletedTxt.GetComponent<TextMeshProUGUI>().text = "Levels Completed: " + PlayerPrefs.GetInt("LevelsCompleted");
    }

    public void backToSettings()
    {
        this.gameObject.SetActive(false);
        SettingsPage.SetActive(true);
    }
}
