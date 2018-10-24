using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGameSP()
    {
        if(GameObject.Find("StateEngine") != null)
        {
            GameObject.Destroy(GameObject.Find("StateEngine"));
        }
        SceneManager.LoadScene("MainScene");
    }
    public void NewGameMP()
    {
        if (GameObject.Find("StateEngine") != null)
        {
            GameObject.Destroy(GameObject.Find("StateEngine"));
        }
        GameObject.Find("GameMode").GetComponent<GameModeManager>().mp = true;
        SceneManager.LoadScene("MainScene");
    }
    public void Exit()
    {
        Debug.Log("check");
        Application.Quit();
    }



    public void BackToMenu()
    {
        GameObject.Destroy(GameObject.Find("StateEngine"));
        GameObject.Destroy(GameObject.Find("GameMode"));
        SceneManager.LoadScene("MainMenu");

    }

    public void RestartGame()
    {
        if (GameObject.Find("StateEngine") != null)
        {
            GameObject.Destroy(GameObject.Find("StateEngine"));
        }
        SceneManager.LoadScene("MainScene");
    }
}
