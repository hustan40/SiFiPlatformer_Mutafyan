using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFlip : MonoBehaviour
{
    private EnemyAI eAi;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        eAi = collision.GetComponent<EnemyAI>();
        eAi.Flip();
    }
}
