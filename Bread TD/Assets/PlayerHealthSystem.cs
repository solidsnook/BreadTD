using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerHealthSystem : MonoBehaviour
{
    public int Health = 3;

    public GameObject LoseScreen;
    public GameObject LevelFinishScreen;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    public GameObject FirstBread;

    public Sprite FullHeart;
    public Sprite NoHeart;

    // Start is called before the first frame update
    void Start()
    {
        LoseScreen.SetActive(false);
        LevelFinishScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreadDie()
    { 
    }

    public void DamageTaken()
    {

        Health = Health - 1;
        Debug.Log("Health -");
        Debug.Log("Health is now" + Health);
        
        
        HeartChecker();
        return;
    }

    public void PlayerLose()
    {
        //pause the 
        Time.timeScale = 0;
        //show lose screen
        LoseScreen.SetActive (true);
        //if retry button press
        //reset scene
        //if quit button press
        //quit game
    }


    public void PlayerLevelFinish()
    {
        //pause the game
        //show win screen
        //if next level button press
            //start next scene
        //if quit button pressed
            //quit game
    }


    public void HeartChecker()
    {
        if (Health == 3) 
        {
            Life1.GetComponent<Image>().sprite = FullHeart;
            Life2.GetComponent<Image>().sprite = FullHeart;
            Life3.GetComponent<Image>().sprite = FullHeart;
        }
        if (Health == 2)
        {
            Life3.GetComponent<Image>().sprite = NoHeart;

            //Life3.SetActive(false);
        }
        if (Health == 1)
        {
            Life2.GetComponent<Image>().sprite = NoHeart;
        }
        if (Health <= 0)
        {
            Life1.GetComponent<Image>().sprite = NoHeart;
            PlayerLose();
        }
    }
}
