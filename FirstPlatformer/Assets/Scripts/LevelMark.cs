using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMark : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetSceneName()
    {
        return sceneName;
    }
}
