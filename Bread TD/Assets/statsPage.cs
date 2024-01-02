using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class statsPage : MonoBehaviour
{
    public GameObject BreadsDestroyedTxt;
    public int BreadCopper;
    public int BreadSilver;
    public int BreadGold;
    public Image BreadsBadge;

    public GameObject CrumbsSpentTxt;
    public int CrumbsCopper;
    public int CrumbsSilver;
    public int CrumbsGold;
    public Image CrumbsBadge;

    public GameObject TowersPlacedTxt;
    public int TowersCopper;
    public int TowersSilver;
    public int TowersGold;
    public Image TowersBadge;

    public GameObject LifeLostTxt;
    public int LifeCopper;
    public int LifeSilver;
    public int LifeGold;
    public Image LifeBadge;

    public GameObject TimePlayedTxt;
    public int TimeCopper;
    public int TimeSilver;
    public int TimeGold;
    public Image TimeBadge;

    public GameObject LevelsCompletedTxt;
    public int LevelsCopper;
    public int LevelsSilver;
    public int LevelsGold;
    public Image LevelsBadge;

    public Sprite CopperBadge, SilverBadge, GoldBadge, BasicBadge; 

    public GameObject SettingsPage;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BreadsDestroyed") == false) PlayerPrefs.SetInt("BreadsDestroyed", 0);
        if (PlayerPrefs.HasKey("CrumbsSpent") == false) PlayerPrefs.SetInt("CrumbsSpent", 0);
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
        BreadsDestroyedTxt.GetComponent<TextMeshProUGUI>().text = "Breads Destroyed: " + PlayerPrefs.GetInt("BreadsDestroyed");
        BreadsBadge.GetComponent<Image>().sprite = StageBadgeCheck(PlayerPrefs.GetInt("BreadsDestroyed"), BreadCopper, BreadSilver, BreadGold);

        CrumbsSpentTxt.GetComponent<TextMeshProUGUI>().text = "Crumbs Spent: " + PlayerPrefs.GetInt("CrumbsSpent");
        CrumbsBadge.GetComponent<Image>().sprite = StageBadgeCheck(PlayerPrefs.GetInt("CrumbsSpent"), CrumbsCopper, CrumbsSilver, CrumbsGold);

        TowersPlacedTxt.GetComponent<TextMeshProUGUI>().text = "Towers Placed: " + PlayerPrefs.GetInt("TowersPlaced");
        TowersBadge.GetComponent<Image>().sprite = StageBadgeCheck(PlayerPrefs.GetInt("TowersPlaced"), TowersCopper, TowersSilver, TowersGold);

        LifeLostTxt.GetComponent<TextMeshProUGUI>().text = "Life Lost: " + PlayerPrefs.GetInt("LifeLost");
        LifeBadge.GetComponent<Image>().sprite = StageBadgeCheck(PlayerPrefs.GetInt("LifeLost"), LifeCopper, LifeSilver, LifeGold);

        TimePlayedTxt.GetComponent<TextMeshProUGUI>().text = "Time Played: " + PlayerPrefs.GetInt("TimePlayed");
        TimeBadge.GetComponent<Image>().sprite = StageBadgeCheck(PlayerPrefs.GetInt("TimePlayed"), TimeCopper, TimeSilver, TimeGold);

        LevelsCompletedTxt.GetComponent<TextMeshProUGUI>().text = "Levels Completed: " + PlayerPrefs.GetInt("LevelsCompleted");
        LevelsBadge.GetComponent<Image>().sprite = StageBadgeCheck(PlayerPrefs.GetInt("LevelsCompleted"), LevelsCopper, LevelsSilver, LevelsGold);
    }

    Sprite StageBadgeCheck(int statAmount, int copper, int silver, int gold)
    {
        if(statAmount >= copper && statAmount < silver)
        {
            return CopperBadge;
        }
        if(statAmount >= silver && statAmount < gold)
        {
            return SilverBadge;
        }
        if(statAmount >= gold)
        {
            return GoldBadge;
        }
        return BasicBadge;
    }

    public void backToSettings()
    {
        this.gameObject.SetActive(false);
        SettingsPage.SetActive(true);
    }
}
