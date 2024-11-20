using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton, pausePanel;
    
    public void PauseBut()
    {
        pauseButton.gameObject.SetActive(!pauseButton.activeSelf);
        pausePanel.SetActive(!pausePanel.activeSelf);
        
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        
    }

    public void RestarLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MuteAllSound()
    {
        if(AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    

}
