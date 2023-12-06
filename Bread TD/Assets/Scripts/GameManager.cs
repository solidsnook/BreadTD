using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data.SqlTypes;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //values needed to be persistant accross scenes
    private static int Score = 0;

    static List<bool> lvlLockList; //list of locked and unlocked waves

    //wave list for level
    public List<GameObject> lvlWaves;

    //bread
    public List<GameObject> AliveBreads;

    //lvl variables
    public GameObject WaveAlert;
    GameObject wave;

    public int Lives;
    int lvlScore;
    int waveNum;
    int currentWave;
    int waveDelay;
    int CurrentScene;
    bool WaveFinished = false;


    //health
    public GameObject HealthSystem;

    //Money
    int Crumbs;

    //text variables
    public TextMeshProUGUI Wavestxt, Crumbstxt, ScoreText;

    //temp
    public GameObject LoseScreen;
    public GameObject LevelFinishScreen;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex; 

        //check if not menu scene
        if(CurrentScene == 0)
        { 
            return;
        }

        //setup lvl defaults
        Lives = 3;
        lvlScore = 0;
        waveNum = 1;
        Crumbs = 100;

        UpdateTextValues();

        StartWave(waveNum);

        //temp
        LoseScreen.SetActive(false);
        LevelFinishScreen.SetActive(false);
    }

    void FixedUpdate()
    {
        //check if wave finsihed
        if (AliveBreads.Count <= 0 && WaveFinished)
        {
            //start next wave
            waveNum++;
            StartWave(waveNum);
        }
    }

    /*Private Functions*/
    bool LoadLevel(int lvl)
    {
        //first check if level is locked and return false if it is
        if (IsLevelLocked(lvl)) return false;

        return true;
    }

    void finishLevel()
    {
        //////TEMPORARY Check if menu scene: Remove when adding end lvl screen//////
        if(CurrentScene == 0)
        {
            return;
        }

        //need to add lvl score to total score
        Score += lvlScore;

        //////TEMPORARY: next level loaded after final level done need to remove when adding the end lvl screen//////
        int ActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ActiveSceneIndex++;
        SceneManager.LoadScene(ActiveSceneIndex);

        //open end of level screen
    }

    void StartWave(int WaveNum)
    { 
        //lvl is finished when all waves are done
        if (lvlWaves.Count < WaveNum)
        {
            Debug.Log("all Waves Finished");
            finishLevel();

            return;
        }

        Debug.Log("Wave Started" + WaveNum);
        WaveFinished = false;

        wave = lvlWaves[waveNum - 1];

        //start wave Alert
        WaveAlert.GetComponent<WaveTextMover>().WaveAlert(WaveNum);

        //start wave 
        wave.GetComponent<WaveScript>().StartSpawn();

        //Update text values
        UpdateTextValues();
    }

    //Not Implimented yet
    bool IsLevelLocked(int level) 
    {
        //check if specific level is locked
        bool lvllocked = lvlLockList[level];
        
        return lvllocked;
    }

    /*Public Functions*/
    public void FinishWave()
    {
        Debug.Log("Wave" + waveNum + "finished");
        WaveFinished = true;
    }

    public void RemoveBread(GameObject bread)
    {
        AliveBreads.Remove(bread);
    }

    //functions for crumbs(Money) system
    public void AddCrumbs(int crumAmount)
    {
        Crumbs += crumAmount;

        UpdateTextValues();
    }

    public bool RemoveCrumbs(int crumAmount)
    {
        //if crum cost is too high for balence return false to identify that the cost cannot be paid
        if (Crumbs - crumAmount < 0)
        {
            return false;
        }

        Crumbs -= crumAmount;

        UpdateTextValues();

        return true;
    }

    public void LoseLife()
    {
        Lives -= 1;
        HealthSystem.GetComponent<PlayerHealthSystem>().LoseHelth();

        if (Lives == 0)
        {
            GameOver();
        }
    }

    public void UpdateTextValues()
    {
        //setup text values
        Wavestxt.text = "WAVES: " + waveNum + "/" + lvlWaves.Count;
        Crumbstxt.text =  Crumbs + " Crumbs ";
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(CurrentScene);
    }

    void GameOver()
    {
        // load GameOver Screen
        Time.timeScale = 0.0f;
        LoseScreen.SetActive(true);
    }

    private void OnApplicationPause(bool pause)
    {
      
    }
}
