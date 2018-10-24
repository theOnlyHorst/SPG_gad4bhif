using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public int lives = 3;
    public int score = 0;
    public int targetCount;

    private Text livestxt;

    private Text scoretxt;
    public void loseLive()
    {
        lives--;
        if (livestxt != null)
            livestxt.text = lives.ToString();
    }

    public void targetDestroyed(int score)
    {
        this.score+=score;
        targetCount--;
        if(targetCount==0)
        {
            SceneManager.LoadScene("EndScene");
        }
        if (scoretxt != null)
            scoretxt.text = this.score.ToString();
    }

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Lives") != null)
        {
            livestxt = GameObject.Find("Lives").GetComponent<Text>();
            livestxt.text = lives.ToString();
        }
        if (GameObject.Find("Score") != null)
        {
            scoretxt = GameObject.Find("Score").GetComponent<Text>();
            scoretxt.text = score.ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
