using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;
    private CharacterController _controller;

    private float xMov;
    private float zMov;

    private int iFrames;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        xMov = Input.GetAxisRaw("X-Movement");
        zMov = Input.GetAxisRaw("Z-Movement");

        
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3();
        movement.x = xMov*movementSpeed*Time.fixedDeltaTime;
        movement.z = zMov* movementSpeed*Time.fixedDeltaTime;
        if(GameManager.Instance.IsInBounds(transform.position+movement))
        _controller.Move(movement);

        if(iFrames>0)
        {
            iFrames--;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Damaging Player"&&iFrames==0)
        {
            iFrames = GameManager.Instance.maxIFrames;
            GameManager.Instance.PlayerTakeDamage();
            
        }
    }

}
