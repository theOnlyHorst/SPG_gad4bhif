using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StateManager st = GameObject.Find("StateEngine").GetComponent<StateManager>();
        GetComponent<Text>().text = GameObject.Find("GameMode").GetComponent<GameModeManager>().getResultText(st.scoreLeft,st.scoreRight);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
