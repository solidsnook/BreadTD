using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //values needed to be persistant accross scenes
    private static int Score = 0;

    static List<bool> lvlLockList; //list of locked and unlocked waves

    //wave list for level
    public List<GameObject> lvlWaves;

    //bread list
    public List<GameObject> AliveBreads;

    //lvl values
    int Lives;
    int lvlScore;
    int waveNum;
    GameObject wave;
    int currentWave;
    int waveDelay;

    int breadCount;

    bool WaveFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        //setup lvl defaults

        Lives = 3;
        lvlScore = 0;
        waveNum = 1;

        StartWave(waveNum);
    }

    void FixedUpdate()
    {
        //check if wave finsihed
        if (AliveBreads.Count == 0 && WaveFinished)
        {
            //wave Finished start new wave
            waveNum++;
            StartWave(waveNum);
        }
    }

    bool LoadLevel(int lvl)
    {
        //first check if level is locked and return false if it is
        if (IsLevelLocked(lvl)) return false;

        return true;
    }

    void finishLevel()
    {
        //need to add lvl score to total score
        Score += lvlScore;

        //open level finsih Ui
    }

    void StartWave(int WaveNum)
    { 
        //lvl is finished when all waves are done
        if (lvlWaves.Count < WaveNum)
        {
            Debug.Log("all Waves Finished");
            return;
        }

        Debug.Log("Wave Started" + WaveNum);
        WaveFinished = false;

        wave = lvlWaves[waveNum - 1];

        //start wave 
        wave.GetComponent<WaveScript>().StartSpawn();

        //delay before wave starts
        //wave.GetComponent<waveScript>().startDelay;
    }

    public void FinishWave()
    {
        //make sure all enemies are dead before finishing
        Debug.Log("Wave" + waveNum + "finished");
        WaveFinished = true;
    }

    bool IsLevelLocked(int level) 
    {
        //check if specific level is locked
        bool lvllocked = lvlLockList[level];
        
        return lvllocked;
    }

    private void OnApplicationPause(bool pause)
    {
      
    }
}
