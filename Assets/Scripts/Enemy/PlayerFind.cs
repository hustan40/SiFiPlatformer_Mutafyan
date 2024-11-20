using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFind : MonoBehaviour
{
    [SerializeField]private EnemyAI eAi;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            eAi.State(2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            eAi.State(1);
        }
    }
}
