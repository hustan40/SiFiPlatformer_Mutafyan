using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishLvlTrigger : MonoBehaviour
{
    [SerializeField] EndLvl endlvl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            endlvl.WinPanel();
            Time.timeScale = 0;
        }
    }
}
