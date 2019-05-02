using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance{
        get{return m_instance;}
    }

    void Awake()
    {
        if(m_instance == null)
            m_instance = this;
        else
            Debug.LogError("There may only be one GameManager!");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
