using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {
    
    [SerializeField]
    private KeyCode left, right;


    private bool leftSw, rightSw;
    private SpriteRenderer rend;
   

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(left)) leftSw = true;
        if (Input.GetKey(right)) rightSw = true;
	}
    private void FixedUpdate()
    {
        if(leftSw)
        {
            transform.Translate(new Vector2(-0.1f,0));
            if (!rend.flipX)
                rend.flipX = true;
            leftSw = false;
        }
        if (rightSw)
        {
            transform.Translate(new Vector2(0.1f, 0));
            if (rend.flipX)
                rend.flipX = false;
            rightSw = false;
        }

    }
}
