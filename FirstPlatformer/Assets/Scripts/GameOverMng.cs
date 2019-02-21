using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMng : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        var mark = GameObject.FindGameObjectWithTag("LevelMark");
        if(mark==null)
        {
            return;
        }
        var markScr = mark.GetComponent<LevelMark>();
        var scene = markScr.GetSceneName();
        GameObject.Destroy(mark);
        SceneManager.LoadScene(scene);
    }

}
