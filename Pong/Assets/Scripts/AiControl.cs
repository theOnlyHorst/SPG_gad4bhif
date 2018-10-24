using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour {

    private GameObject ball;
    private Rigidbody2D rig;

    private readonly int checkTimeMax = 3;
    private int checkCycle;

    private bool upMove, downMove;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        if (checkCycle >= checkTimeMax)
        {
            checkCycle = 0;
            upMove = false;
            downMove = false;
            if (transform.position.y < ball.transform.position.y)
                upMove = true;

            if (transform.position.y > ball.transform.position.y)
                downMove = true;
            if(transform.position.y == ball.transform.position.y)
            {

            }
           
        }
        else
        {
            checkCycle++;
        }

        if(upMove)
        {
            transform.Translate(new Vector2(0, 0.1f));
            if(transform.position.y == ball.transform.position.y)
            {
                upMove = false;
            }
        }
        if(downMove)
        {
            transform.Translate(new Vector2(0, -0.1f));
            if (transform.position.y == ball.transform.position.y)
            {
                downMove = false;
            }
        }
        if(ball.transform.position.x ==0 && ball.transform.position.y ==0)
        {
            transform.position = new Vector2(6.418127f,0);
        }
    }
}
