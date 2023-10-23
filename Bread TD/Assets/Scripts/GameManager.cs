using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //values needed to be persistant accross scenes
    static int Score;

    static List<bool> lvlLockList; //just showes if a level is unlocked or not

    //list of levels
    

    //lvl values
    int Lives;
    int lvlScore;
    int wave;
    int currentWave;
    int waveDelay;

    // Start is called before the first frame update
    void Start()
    {
        Lives = 3; lvlScore = 0; wave = 1;
        StartWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        //first check if level is locked

        //need to add lvl score to total score
    }

    void StartWave(int waveNum)
    {
        //delay before wave starts
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
}
