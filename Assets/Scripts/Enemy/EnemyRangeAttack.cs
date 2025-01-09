using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Animator anim;
    public void Attack()
    {
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectal>().SetDirection(Mathf.Sign(transform.localScale.x));
        fireballs[FindFireball()].GetComponent<Projectal>().damageDeal = 2;
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
