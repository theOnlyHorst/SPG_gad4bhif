using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDisappear : MonoBehaviour {

    private ScoreTracker sc;
    public int scoreRewarded;
    private BallCharge bc;
    Collider2D coll;
    SpriteRenderer sp;
	// Use this for initialization
	void Start () {
        sc = GameObject.Find("GameManager").GetComponent<ScoreTracker>();
        bc = GameObject.FindGameObjectWithTag("Player").GetComponent<BallCharge>();
        coll = GetComponent<Collider2D>();
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            sc.targetDestroyed(scoreRewarded);
            sp.color = Color.black;
            Physics2D.IgnoreCollision(collision.collider,coll,true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sc.targetDestroyed(scoreRewarded);
            sp.color = Color.black;
            Physics2D.IgnoreCollision(collision, coll, true);
        }
    }

}
