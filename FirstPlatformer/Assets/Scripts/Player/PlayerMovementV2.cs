using Prime31;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementV2 : MonoBehaviour
{
    //Physics Config
    
    public float gravity = -25f;
    public float runSpeed = 30f;
    public float runSpeedInAirMultiplier = 1f;
    public float jumpTime = 10f;
    public float jumpStrength = 1f;
    public float jumpBoardBounce = 1f;
    public float jumpBoardHitDelay = 0.2f;
    public float jumpBoardBoostMultiplier = 1.5f;
    public float knockbackStrength = 3f;
    public float runAnimSpeed = 1f;
    //----------------------------------
    private CharacterController2D _controller;
    private Animator _animator;
    private RaycastHit2D _lastControllerColliderHit;
    private float normalizedHorizontalSpeed = 0;
    private Vector3 _velocity;
    private SpriteRenderer spriteRenderer;
    private GameObject respawn;
    private bool jumping;
    private bool jumpBoard;
    private bool jumpBoardBoost;
    private float jumpBoardHitDelayTimer;


    [SerializeField]
    private UnityEvent onRespawn;

    private float jumpTimer;


    private int miniFrameDelay = 5;
    private int FrameDelayTimer=0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CharacterController2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        respawn = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!(FrameDelayTimer >= miniFrameDelay))
        {
            FrameDelayTimer++;
        }
            //Debug.Log(_animator.GetBool("jumping"));
        if(_controller.isGrounded)
        {
            _velocity.y = 0;
            if (FrameDelayTimer>=miniFrameDelay)
            _animator.SetBool("jumping", false);
        }
        var jmpMov = Input.GetAxis("Jump");
       
        if (jumping)
        {
            float tmpy = -gravity * Time.deltaTime * jumpStrength;
            if (jumpBoardBoost)
                tmpy *= jumpBoardBoostMultiplier;
            _velocity.y = tmpy;
            //Debug.Log(1-jmpMov);
            jumpTimer += Time.deltaTime;
        }
        
        
        if (jumpTimer>=jumpTime||jmpMov==0)
        {
            jumping = false;
            jumpBoardBoost = false;
            jumpTimer = 0;
            //Debug.Log("jumpEnd");
        }
        if (_controller.isGrounded && Input.GetButtonDown("Jump") && !jumpBoard)
        {

            jumping = true;
            jumpTimer = 0;
            FrameDelayTimer = 0;
            _animator.SetBool("jumping", true);
        }
        if (jumpBoard)
        {
            jumpBoardHitDelayTimer -= Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                jumping = true;
                _velocity.y += -gravity * jumpBoardBounce*2;
                _animator.SetBool("jumping", true);
                jumpBoard = false;
                jumpBoardBoost = true;
            }
            else
            {
                if (jumpBoardHitDelayTimer <= 0)
                {
                    _velocity.y += -gravity * jumpBoardBounce;
                    _animator.SetBool("jumping", true);
                    jumpBoard = false;
                }
            }
        }
        
        
        var xMov = Input.GetAxis("Horizontal");
        _animator.SetFloat("walkspeed", Math.Abs(xMov)*runAnimSpeed);

        if (xMov < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }
        if (xMov > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
       

        if(_controller.isGrounded)
            _velocity.x = runSpeed * xMov;
        else
            _velocity.x = runSpeed * xMov * runSpeedInAirMultiplier;
      
        _velocity.y += gravity * Time.deltaTime;

        


        _controller.move(_velocity*Time.deltaTime);

        //Debug.Log(_velocity.y*Time.deltaTime);


    }

    public void onJumpboardHit()
    {
        //Debug.Log("Trigger hit");
        jumpBoard = true;
        jumpBoardHitDelayTimer = jumpBoardHitDelay;
    }

 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Killzone")
        {
            transform.position = respawn.transform.position;
            onRespawn.Invoke();
        }
    }

    
}
