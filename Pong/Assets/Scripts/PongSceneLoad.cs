using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongSceneLoad : MonoBehaviour {

  
    [SerializeField]
    public int aiControlOverride;

    // Use this for initialization
    void Start () {
        if(GameObject.Find("GameMode")==null)
        {
            if (aiControlOverride ==1)
            {
                GameObject aiRack = GameObject.FindGameObjectWithTag("Ai");
                aiRack.AddComponent<AiControl>();
            }
        }
        else
        if (!GameObject.Find("GameMode").GetComponent<GameModeManager>().mp)
        {
            GameObject aiRack = GameObject.FindGameObjectWithTag("Ai");
            aiRack.AddComponent<AiControl>();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
