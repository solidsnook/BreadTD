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

    public GameObject KetchupDes;
    public GameObject MustardDes;
    public GameObject MayoDes;

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
    }

    private void RescaleCamera()
    {

        if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;
        //Camera camera = GetComponent<Camera>();

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

    public void PlayGame()
    {
        //set this to the main game scene
        SceneManager.LoadScene("Scenes/Level1");
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
