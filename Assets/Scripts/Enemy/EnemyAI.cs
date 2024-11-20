using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool allowToMove;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private int dir = 1;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        State(1);
    }
    private void Update()
    {
        if (allowToMove == true)
        {
            rb.velocity = new Vector2(speed * dir, rb.velocity.y);
        }    
    }

    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        dir *= -1;
    }

    public void State(byte currentState)
    {
        switch (currentState)
        {
            case 1: //Движение
                anim.SetBool("Move", true);
                allowToMove = true;
                break;
            case 2: //Атака
                anim.SetBool("Move", false);
                anim.SetTrigger("Attack");
                allowToMove = false;
                break;
            default:
                anim.SetBool("Move", false);
                break;
        }
    }
}
