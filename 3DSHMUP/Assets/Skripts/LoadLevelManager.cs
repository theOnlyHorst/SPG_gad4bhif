using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.spawnpoints.AddRange(GameObject.FindGameObjectsWithTag("Spawnpoint"));
        GameManager.Instance.InitLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
