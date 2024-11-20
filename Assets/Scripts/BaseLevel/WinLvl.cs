using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinLvl : MonoBehaviour
{
    private int score, maxscore;
    public TextMeshProUGUI scoretxt, maxscoretxt;
    void Awake()
    {
        score = PlayerPrefs.GetInt("total score");
        maxscore = PlayerPrefs.GetInt("max score");

        if (score >= maxscore)
        {
            maxscore = score;
            PlayerPrefs.SetInt("max score", maxscore);
        }
        scoretxt.text = score.ToString();
        maxscoretxt.text = maxscore.ToString();
    }

    public void ButtonReturn()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("total score", 0);
    }
}
