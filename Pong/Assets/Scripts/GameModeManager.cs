using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour {

    public bool mp;
    private string winText = "You Won!";
    private string loseText = "You Lost :(";
    private string leftWinText = "Left Wins!";
    private string rightWinText = "Right Wins!";
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getResultText(int scLeft,int scRight)
    {
        if(mp)
        {
            if(scLeft>scRight)
            {
                return leftWinText;
            }
            else { return rightWinText; }
        }
        else
        {
            if (scLeft > scRight)
            {
                return winText;
            }
            else return loseText;
        }
    }
}
