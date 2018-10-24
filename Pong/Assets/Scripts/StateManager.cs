using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {


    public bool playing = false;
    public int scoreLeft = 0;
    public int scoreRight = 0;

    private static readonly int winScore = 5;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckScore()
    {
        if(scoreRight == winScore || scoreLeft == winScore)
        {
            SceneManager.LoadScene("EndMenu");
            
        }
    }
}
