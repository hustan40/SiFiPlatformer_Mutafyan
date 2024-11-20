using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private GameObject mainMenu, settingsMenu, quitgame;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsGame()
    {

        if (mainMenu.activeSelf == true)
        {
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    public void GameQuitConfirmed()
    {

        if (mainMenu.activeSelf == true)
        {
            quitgame.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            quitgame.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
