using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    LayerMask maskGround;

    private Rigidbody2D body;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        maskGround = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        anim.SetBool("Run", Input.GetAxis("Horizontal") != 0);
        anim.SetBool("Jump", !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.down, 0.1f, maskGround)); 
    }
}
