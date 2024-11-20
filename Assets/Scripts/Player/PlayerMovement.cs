using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed, jumpForce;
    private CapsuleCollider2D capsuleCollider;
    private Rigidbody2D body;
    private Animator anim;
    private bool onGround, crouch;
    private float horizontalInput;
    LayerMask maskGround;
    Health health;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        maskGround = LayerMask.GetMask("Ground");
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (health.healthPoint > 0)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

        FlipSprite(horizontalInput);

        if (Input.GetKey(KeyCode.W) && onGround && health.healthPoint > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl) && onGround && health.healthPoint > 0)
        {
            capsuleCollider.offset = new Vector2(0f, -0.12f);
            capsuleCollider.size = new Vector2(0.12f, 0.24f);
            anim.SetBool("Crouch", true);
            crouch = true;
            speed *= 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && health.healthPoint > 0)
        {
            capsuleCollider.offset = new Vector2(0f, -0.04f);
            capsuleCollider.size = new Vector2(0.12f, 0.4f);
            anim.SetBool("Crouch", false);
            crouch = false;
            speed *= 2f;
        }



    }

    private void FixedUpdate()
    {
        
        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.down, 0.1f, maskGround))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
    
    private void FlipSprite(float horinput) //Меняет сторону спрайта в зависимости от движения игрока
    {
        if (horinput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horinput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public bool canAttack()
    {
        return !crouch && health.healthPoint > 0;
    }
}
