using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour {
    [SerializeField]
    private KeyCode up, down ,sprint;

   
    private bool upSwitch, downSwitch, sprintSwitch,controllable;
	// Use this for initialization
	void Start () {
        if(GameObject.Find("GameMode")==null)
        {
            if (tag != "Ai")
                    controllable = true;
            if (GameObject.Find("LoadScene").GetComponent<PongSceneLoad>().aiControlOverride != 1)
                controllable = true;
        }
        else
        if(tag == "Ai")
        controllable = GameObject.Find("GameMode").GetComponent<GameModeManager>().mp;
        else
        {
            controllable = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(up)) upSwitch = true;
        if (Input.GetKey(down)) downSwitch = true;
        if (Input.GetKey(sprint)) sprintSwitch = true;
    }
    void FixedUpdate()
    {
        if(!controllable)
        {
            return;
        }
        if(upSwitch)
        {
            if (sprintSwitch)
            {
                transform.Translate(new Vector2(0.0f, 0.2f));
                
            }
            else
                transform.Translate(new Vector2(0.0f, 0.1f));
            upSwitch = false;
        }
        if(downSwitch)
        {
            if (sprintSwitch)
            {
                transform.Translate(new Vector2(0.0f, -0.2f));
            }
            else
                transform.Translate(new Vector2(0.0f, -0.1f));
            downSwitch = false;
        }
        if(sprintSwitch)
        {
            sprintSwitch = false;
        }
    }
}
