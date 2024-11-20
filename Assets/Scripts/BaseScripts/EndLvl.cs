using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{
    [SerializeField] private Health hpPlayer;
    [SerializeField] private InfoUpdate info;
    private float timePlayer;
    [SerializeField] private int timeCoef, scoreToHealth;

    void Awake()
    {
        timePlayer = 0;
        scoreToHealth = 500;
    }
    void Update()
    {
        timePlayer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
      
        if (info.score >= scoreToHealth)
        {
            hpPlayer.healthPoint++;
            scoreToHealth += scoreToHealth;
        }    

        if (hpPlayer.healthPoint <= 0)
        {
            LosePanel();
        }
    }
    public void WinPanel()
    {
        info.score += (ScoreTimePoint() * 5);
        PlayerPrefs.SetInt("total score", info.score);
        SceneManager.LoadScene(2);
    }
    public void LosePanel()
    {
        info.score += ScoreTimePoint();
        PlayerPrefs.SetInt("total score", info.score);
        SceneManager.LoadScene(3);
    }
    
    private int ScoreTimePoint()
    {
       if (timePlayer >= 60)
       {
            return 0;
       }
       else
       {
            return (60 - Convert.ToInt32(timePlayer)) * timeCoef;  
       }
       
    }
}
