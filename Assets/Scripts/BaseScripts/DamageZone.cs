using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageDeal, maxtimeToDamage;
    private float timeToDamage = 0;
    private bool inDanger = false;
    private Health health;
    [SerializeField] private string enemyName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyName))
        {
            
            inDanger = true;
            timeToDamage = 0;
            health = collision.gameObject.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyName))
        {
            inDanger = false;
            timeToDamage = 0;
        } 
    }
    private void Update()
    {
        if (inDanger == true)
        {
            timeToDamage += Time.deltaTime;
            
            if (timeToDamage >= maxtimeToDamage)
            {
                health.Damage(damageDeal);
                timeToDamage = 0;
            }
        }
    }
}
