﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEndLives : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = GameObject.Find("GameManager").GetComponent<ScoreTracker>().lives.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
