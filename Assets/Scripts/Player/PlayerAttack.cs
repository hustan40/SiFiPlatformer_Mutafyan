using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1, reloadCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private int bulletsMax;
    private PlayerMovement playerMovement;
    private InfoUpdate infoUpdate;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity, reloadTimer = Mathf.Infinity;
    public int bulletsCount;
    [SerializeField] private Image cooldown;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        bulletsCount = bulletsMax;
        infoUpdate = FindAnyObjectByType<InfoUpdate>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer >= attackCooldown && playerMovement.canAttack() && bulletsCount > 0)
        {
            Attack();
            bulletsCount--;
            infoUpdate.bullet.text = bulletsCount.ToString();
        }


        if (Input.GetKey(KeyCode.R))
        {
            bulletsCount = 0;
            infoUpdate.bullet.text = bulletsCount.ToString();
            reloadTimer = 0;
        }

        if (Input.GetMouseButtonDown(0) && bulletsCount <= 0)
        {
            reloadTimer = 0;
        }

        if (bulletsCount == 0)
        {
            reloadTimer += Time.deltaTime;
            cooldown.fillAmount = reloadTimer / reloadCooldown;

            if (reloadTimer >= reloadCooldown)
            {
                bulletsCount = bulletsMax;
                infoUpdate.bullet.text = bulletsCount.ToString();
            }
        }

        if (cooldownTimer <= attackCooldown)
        {
            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

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
