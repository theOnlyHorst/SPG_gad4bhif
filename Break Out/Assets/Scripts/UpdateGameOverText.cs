using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameOverText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameObject.Find("GameManager").GetComponent<ScoreTracker>().targetCount == 0)
        {
            GetComponent<Text>().text = "YOU WON";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
