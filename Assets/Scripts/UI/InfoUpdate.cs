using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class InfoUpdate : MonoBehaviour
{
    public TextMeshProUGUI bullet, point, hp;
    public int score;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private Health health;
    private void Awake()
    {
        score = 0;
        point.text = score.ToString();
        bullet.text = playerAttack.bulletsCount.ToString();
        hp.text = health.healthPoint.ToString();
    }
    private void Update()
    {
        hp.text = health.healthPoint.ToString();
    }
}
