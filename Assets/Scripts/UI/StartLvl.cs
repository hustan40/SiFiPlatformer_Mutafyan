using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLvl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Awake()
    {
        player.transform.position = transform.position;
        Time.timeScale = 1.0f;
    }
}
