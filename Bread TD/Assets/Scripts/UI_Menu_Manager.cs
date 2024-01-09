using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_Manager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject TowersMenu;
    public GameObject SettingsMenu;
    public GameObject StatsMenu;
    public GameObject LevelMenu;

    public GameObject KetchupDes;
    public GameObject MustardDes;
    public GameObject MayoDes;
    public GameObject EggDes;

    public GameObject bread1Des;
    public GameObject bread2Des;
    public GameObject bread3Des;
    public GameObject bread4Des;
    public GameObject sellDes;


    public Camera camera;

    private int ScreenSizeX;
    private int ScreenSizeY;

    public void Start()
    {
      
        KetchupDes.SetActive(false);
        MustardDes.SetActive(false);
        MayoDes.SetActive(false);

        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        TowersMenu.SetActive(false);
        StatsMenu.SetActive(false);
        LevelMenu.SetActive(false);
        sellDes.SetActive((false));

        if (PlayerPrefs.HasKey("LevelProgression") == false) PlayerPrefs.SetInt("LevelProgression", 1);
    }

    private void RescaleCamera()
    {
        //check if camera is not null
        if (camera == null)
        {
            Debug.Log("Event System Camera Not Assigned");
            return;
        }

        if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        //dont need this as camera will be assigned in editor
        //camera = GetComponent<Camera>(); 

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
    }

    private void Update()
    {
        RescaleCamera();
    }

    public void PlayGame(int SceneId)
    {
        if(PlayerPrefs.GetInt("LevelProgression") < SceneId)
        {
            Debug.Log("Level Is Locked");
            return;
        }

        //load selected lvl scene
        SceneManager.LoadScene(SceneId);
    }

    public void BackToMenu(GameObject CurrentMenu)
    {
        CurrentMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OpenMenu(GameObject menu)
    {
        MainMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void KetchupDescription()
    {
        KetchupDes.SetActive(true);
    }

    public void MustardDescription()
    {
        MustardDes.SetActive(true);
    }
    public void MayoDescription()
    {
        MayoDes.SetActive(true);
    }
    public void EggDescription()
    {
        EggDes.SetActive(true);
    }
    public void Bread1Description()
    {
        bread1Des.SetActive(true);
    }

    public void Bread2Description()
    {
        bread2Des.SetActive(true);
    }
    public void Bread3Description()
    {
        bread3Des.SetActive(true);
    }
    public void Bread4Description()
    {
        bread4Des.SetActive(true);
    }

    public void SellDescription()
    {
        sellDes.SetActive(true);
    }

    public void CloseDescription(GameObject Description)
    {
        Debug.Log("closing description");
        Description.SetActive(false);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
