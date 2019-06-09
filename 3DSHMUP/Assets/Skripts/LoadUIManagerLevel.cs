using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUIManagerLevel : MonoBehaviour
{

    [SerializeField]
    private Text healthtxt;
    [SerializeField]
    private Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.healthtxt = healthtxt;
        UIManager.Instance.scoretxt = scoretxt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
