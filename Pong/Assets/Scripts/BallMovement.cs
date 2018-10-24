using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private Rigidbody2D body;
    private StateManager man;

    [SerializeField]
    private KeyCode StartMove;

    private bool startMovesw;

    
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        man = GameObject.Find("StateEngine").GetComponent<StateManager>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(StartMove)) startMovesw = true;
	}
    void FixedUpdate()
    {
        if (startMovesw)
        {
            if (!man.playing)
            {
                body.velocity = new Vector2(Random.value < 0.5 ? -5 : 5, Random.value < 0.5 ? -3 : 3);
                man.playing = true;
            }
            startMovesw = false;
        }

    }
}
