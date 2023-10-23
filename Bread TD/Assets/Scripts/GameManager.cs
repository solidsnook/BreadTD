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
    List<GameObject> lvlWaves;

    //bread list
    private List<GameObject> AliveBreads;

    //lvl values
    int Lives;
    int lvlScore;
    int waveNum;
    GameObject wave;
    int currentWave;
    int waveDelay;

    int breadCount;

    // Start is called before the first frame update
    void Start()
    {
        //setup lvl defaults

        Lives = 3;
        lvlScore = 0;
        waveNum = 1;
    }

    void FixedUpdate()
    {
        //check if wave finsihed
        if (AliveBreads.Count == 0)
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
        wave = lvlWaves[waveNum - 1];
        //if wave is null then lvl is finished
        if (wave == null) return;

        //delay before wave starts
        //wave.GetComponent<waveScript>().startDelay;
    }

    void FinishWave()
    {
        //make sure all enemies are dead before finishing
        
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
