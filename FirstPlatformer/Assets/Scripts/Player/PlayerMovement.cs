using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementForce,jumpForce;
    
    //this is used to set the exact amount of frames a player can't jump after jumping once
    [SerializeField]
    private int jumpCoolDownMax;
    [SerializeField]
    private LayerMask groundMask;



    private Rigidbody2D rigid;
    private Animator animCont;
    private GameObject groundPoint;
    private SpriteRenderer spriteRenderer;
    private GameObject mainCam;
    private bool doubleJump;
    private GameObject respawn;
    [SerializeField]
    private UnityEvent onRespawn;

    private float xMov, jmp;

    //this is a cooldown added so the player can't spam the jump and make the charackter look dumb
    private int jmpCoolDown;

    //this int is used to add a slight delay before trying to check if the player is not jumping anymore to prevent the animation from immediatly reverting again
    private int jmpAnimFrameDelay;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        animCont = GetComponentInChildren<Animator>();
        groundPoint = GameObject.Find("GroundPoint");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        mainCam = GameObject.Find("Main Camera");
        respawn = GameObject.FindGameObjectWithTag("Respawn");
	}
	
	// Update is called once per frame
	void Update () {
        if (jmpCoolDown > 0 && IsGrounded())
            jmpCoolDown--;
        if (jmpAnimFrameDelay > 0)
            jmpAnimFrameDelay--;
        xMov = Input.GetAxis("Horizontal");
        animCont.SetFloat("walkspeed", Math.Abs(xMov));
        if (xMov < 0&& !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }
        if(xMov > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
        

        if (Input.GetButtonDown("Jump") && IsGrounded()&&jmpCoolDown==0)
        {
            animCont.SetBool("jumping", true);
            rigid.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            jmpCoolDown = jumpCoolDownMax;
            jmpAnimFrameDelay = 5;
            
        }
        if (Input.GetButtonDown("Jump") &&doubleJump && jmpCoolDown == 0)
        {
            float xV = rigid.velocity.x;
            rigid.velocity = new Vector2(xV, 0);
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jmpCoolDown = jumpCoolDownMax;
        }
        if (animCont.GetBool("jumping")&&IsGrounded()&&jmpAnimFrameDelay==0)
        {
            animCont.SetBool("jumping", false);
        }
    }
    void FixedUpdate()
    {
        if (!IsGrounded())
        {

            rigid.AddForce(new Vector2(xMov * movementForce * 0.5f, 0));
        }
        else
        {
            if (doubleJump)
                doubleJump = false;
            rigid.AddForce(new Vector2(xMov * movementForce, 0));
        }
    }

    public bool IsGrounded()
    {
        Collider2D coll = Physics2D.OverlapCircle(groundPoint.transform.position, 0.01f,groundMask);

        if(coll!=null)
        {
            return true;
        }
        return false;
    }

    public void EnableDoubleJump()
    {
        doubleJump = true;
        jmpCoolDown = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Killzone")
        {
            transform.position = respawn.transform.position;
            onRespawn.Invoke();
        }
    }

    public void PlayerKnockback()
    {
        rigid.velocity = new Vector2(0, 0);
        rigid.AddForce(new Vector2(spriteRenderer.flipX ? movementForce*7:movementForce*-7,0),ForceMode2D.Force);
    }
}
