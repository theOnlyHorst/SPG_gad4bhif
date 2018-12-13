using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScoreUpdate : MonoBehaviour {

    private Text scoreboard;
    

	// Use this for initialization
	void Start () {
        scoreboard = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateCoinScore(int score)
    {
        scoreboard.text = "x" + score;
    }


}
