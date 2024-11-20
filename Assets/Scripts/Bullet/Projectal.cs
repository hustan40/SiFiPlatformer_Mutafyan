using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioSource expl;
    private bool hit = false;
    private float direction;
    private float lifeTime = 0;
    private BoxCollider2D boxCollider;
    private Animator anim;

    public int damageDeal;
    [SerializeField] private string enemyName;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (hit)
        {
            return;
        }

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);
        lifeTime += Time.deltaTime;

        if (lifeTime > 5) 
        {
            Deactivate();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyName))
        {
            collision.gameObject.GetComponent<Health>().Damage(damageDeal);
        }

        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("Explode");
        ExplosionSound();

    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    private void ExplosionSound()
    {
        expl.Play(0);
    }
}
