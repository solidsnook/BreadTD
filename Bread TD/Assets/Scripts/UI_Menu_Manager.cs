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

    public void Start()
    {
        KetchupDes.SetActive(false);
        MustardDes.SetActive(false);
        MayoDes.SetActive(false);

        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        TowersMenu.SetActive(false);
    }

    public void PlayGame()
    {
        //set this to the main game scene
        SceneManager.LoadScene("Scenes/LevelLayoutTemplate");
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
