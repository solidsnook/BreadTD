using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YesButton()
    {
        int setActiveScene = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(setActiveScene);

    }


    public void NoButton()
    {
        SceneManager.LoadScene(0);
    }
}
