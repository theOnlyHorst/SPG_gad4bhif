using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScoreUpdate : MonoBehaviour {

    private PlayerHealth health;

    private Text healthText;

	// Use this for initialization
	void Start () {
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
        healthText = GetComponent<Text>();
        healthText.text = "x" + health.GetStartHealth();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHealthScore()
    {
        healthText.text = "x" + health.GetHealth();
    }
}
