using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int damageDeal;
    [SerializeField] private string enemyName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyName))
        {
            collision.gameObject.GetComponent<Health>().Damage(damageDeal);
        }

    }
}
