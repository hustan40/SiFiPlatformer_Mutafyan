using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    public int healthPoint;
    [Range(1,5)]
    public int maxHP;
    [Range(0, 2)]
    public float invTimeMax;
    public int scoreEarn;
    [SerializeField] private GameObject[] toDeactivate;
    private Animator animator;
    private InfoUpdate infoUpdate;
    private bool invic ;
    private float invTime;

    private void Awake()
    {
        healthPoint = maxHP;
        animator = GetComponent<Animator>();
        invic = false;
        infoUpdate = FindAnyObjectByType<InfoUpdate>();
        infoUpdate.hp.text = healthPoint.ToString();
    }

    private void Update()
    {
        if (invic)
        {
            invTime += Time.deltaTime;

            if (invTime >= invTimeMax)
            {
                invic = false;
            }
        }
    }
    public void Damage(int damageINC)
    {
        if (!invic)
        {
            healthPoint -= damageINC;
            animator.SetTrigger("Hit");
            invTime = 0;
            invic = true;

            if (healthPoint <= 0)
            {
                infoUpdate.score += scoreEarn;
                infoUpdate.point.text = infoUpdate.score.ToString();
                Death();

            }
        }
    }
        
    public void Death()
    {
        foreach (GameObject coolid in toDeactivate)
        {
            coolid.SetActive(false);
        }

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
    }

    public void Dissapear()
    {
        gameObject.SetActive(false);
    }
}
