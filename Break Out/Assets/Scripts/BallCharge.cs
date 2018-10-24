using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCharge : MonoBehaviour {


    //Hilfe das Feature funktioniert außerhalb des Editors nicht egal was ich mach
    //Innerhalb des Editors passt das so

    private SpriteRenderer sp;
    public List<Collider2D> targetcolls;
    private Collider2D ballColl;
    private Rigidbody2D ballrig;

    public bool chargeEnabled;
	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
        targetcolls = new List<Collider2D>();
        ballColl = GetComponent<Collider2D>();
        ballrig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChargeTrigger()
    {
        sp.color = Color.red;
        ballrig.velocity = new Vector2(ballrig.velocity.x*2f,ballrig.velocity.y*2f);
        chargeEnabled = true;
        targetcolls.ForEach(x=>x.isTrigger = true);
    }
    public void targetCollsLoad(List<GameObject> targets)
    {
        targets.ForEach(x=> targetcolls.Add(x.GetComponent<Collider2D>()));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="wall"&&chargeEnabled)
        {
            chargeEnd();
        }
    }
    public void chargeEnd()
    {
        sp.color = Color.white;
        targetcolls.ForEach(x => x.isTrigger = false);
        ballrig.velocity = new Vector2(ballrig.velocity.x * 0.5f, ballrig.velocity.y * 0.5f);
        chargeEnabled = false;
    }
}
