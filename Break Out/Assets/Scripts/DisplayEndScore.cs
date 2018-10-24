using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEndScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = GameObject.Find("GameManager").GetComponent<ScoreTracker>().score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
