using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallCollide : MonoBehaviour {


    private Rigidbody2D ballRig;
    
    private Vector2 startpos;
    private Text scoreboardText;
    
    private StateManager man;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject ScoreBoard;
	// Use this for initialization
	void Start () {
        ballRig = ball.GetComponent<Rigidbody2D>();
        
        startpos = new Vector2(0, 0);
        scoreboardText = ScoreBoard.GetComponent<Text>();
        man = GameObject.Find("StateEngine").GetComponent<StateManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            man.playing = false;
            ball.transform.position = startpos;
            ballRig.velocity = new Vector2(0, 0);
            int x = int.Parse(scoreboardText.text);
            x++;
            if (ScoreBoard.name == "ScoreLeft")
                man.scoreLeft = x;
            else
                man.scoreRight = x;
            scoreboardText.text = x.ToString();
            man.CheckScore();
        }
    }
}
