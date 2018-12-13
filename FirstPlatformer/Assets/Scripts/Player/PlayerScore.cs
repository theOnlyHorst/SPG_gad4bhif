using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    private int coins;

    private CoinScoreUpdate scoreboard;

	// Use this for initialization
	void Start () {
        scoreboard = GameObject.Find("CoinScore").GetComponent<CoinScoreUpdate>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addCoins(int coins)
    {
        this.coins += coins;
        scoreboard.UpdateCoinScore(this.coins);
    }
    
}
