using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementForce,jumpForce;
    [SerializeField]
    private int jumpCoolDownMax;
    [SerializeField]
    private LayerMask groundMask;

    private Rigidbody2D rigid;
    private Animator animCont;
    private GameObject groundPoint;
    private SpriteRenderer spriteRenderer;
    private GameObject mainCam;
    private GameObject respawn;

    private float xMov, jmp;

    private int jmpCoolDown;

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
        if (jmpCoolDown > 0)
            jmpCoolDown--;
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
        jmp = Input.GetAxis("Jump");

        if (jmp > 0 && IsGrounded()&&jmpCoolDown==0)
        {
            rigid.velocity = new Vector2(0,jumpForce);
            jmpCoolDown = jumpCoolDownMax;
        }
        
    }
    void FixedUpdate()
    {
        if(!IsGrounded())
        {
            rigid.AddForce(new Vector2(xMov * movementForce*0.5f, 0));
        }
        else
        rigid.AddForce(new Vector2(xMov* movementForce, 0));
    }

    void LateUpdate()
    {
        mainCam.transform.position = new Vector3(transform.position.x, 0,-10);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Killzone")
        {
            transform.position = respawn.transform.position;
        }
    }
}
