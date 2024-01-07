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

    //wave list for level
    public List<GameObject> lvlWaves;

    //bread
    public List<GameObject> AliveBreads;

    //lvl variables
    public GameObject WaveAlert;
    GameObject wave;

    public int Lives;
    int waveNum;
    int currentWave;
    int waveDelay;
    int CurrentScene;
    bool WaveFinished = false;

    float PlayTime;

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
        waveNum = 1;
        Crumbs = 100;
        PlayTime = Time.deltaTime;

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

    void finishLevel()
    {
        //////TEMPORARY Check if menu scene: Remove when adding end lvl screen//////
        if(CurrentScene == 0)
        {
            return;
        }

        PlayTime = Time.deltaTime - PlayTime;
        PlayerPrefs.SetInt("TimePlayed", PlayerPrefs.GetInt("TimePlayed") + (int)PlayTime);

        //////TEMPORARY: next level loaded after final level done need to remove when adding the end lvl screen//////
        int ActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ActiveSceneIndex++;
        PlayerPrefs.SetInt("LevelProgression", ActiveSceneIndex); //unlocks next level
        SceneManager.LoadScene(ActiveSceneIndex);

        //open end of level screen
    }

    void StartWave(int WaveNum)
    {
        ResumeGameTime();
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

    void GameOver()
    {
        // load GameOver Screen
        Time.timeScale = 0.0f;
        LoseScreen.SetActive(true);
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
        //add bread destroyed to player stats
        PlayerPrefs.SetInt("BreadsDestroyed", PlayerPrefs.GetInt("BreadsDestroyed") + 1);
    }

    //functions for crumbs(Money) system
    public void AddCrumbs(int crumbAmount)
    {
        Crumbs += crumbAmount;

        UpdateTextValues();
    }

    public bool RemoveCrumbs(int crumbAmount)
    {
        //if crum cost is too high for balence return false to identify that the cost cannot be paid
        if (Crumbs - crumbAmount < 0)
        {
            Debug.Log("Not Enough Crumbs");
            return false;
        }

        Crumbs -= crumbAmount;

        //update text values
        UpdateTextValues();

        //update crumbs spent stat
        PlayerPrefs.SetInt("CrumbsSpent", PlayerPrefs.GetInt("CrumbsSpent") + crumbAmount);

        return true;
    }

    public void LoseLife()
    {
        Lives -= 1;
        HealthSystem.GetComponent<PlayerHealthSystem>().LoseHelth();

        //update life lost stat
        PlayerPrefs.SetInt("LifeLost", PlayerPrefs.GetInt("LifeLost") + 1);

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
        //restart current level
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(CurrentScene);
    }

    public void MainMenu()
    {
        //Load Menu Scene
        SceneManager.LoadScene(0);
    }

    private void OnApplicationPause(bool pause)
    {
      
    }

    public void ResumeGameTime()
    {
        Time.timeScale = 1.0f;

    }
}
