using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StateManager stat = GameObject.Find("StateEngine").GetComponent<StateManager>();
        this.GetComponent<Text>().text = stat.scoreLeft + "   -   " + stat.scoreRight;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
