using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnEsc : MonoBehaviour {

   
    // Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        //Funktioniert aus witzigen Gründen nicht
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
