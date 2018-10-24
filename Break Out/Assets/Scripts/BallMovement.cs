using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value <=0.5 ? -5:5,3);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
