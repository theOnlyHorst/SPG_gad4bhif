using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEndScreen : MonoBehaviour
{
    [SerializeField]
    private Text resultTxt;
    [SerializeField]
    private Text scoreFinTxt;
    [SerializeField]
    private Text healthFinTxt;
    [SerializeField]
    private Text totalScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.scoreFinTxt = scoreFinTxt;
        UIManager.Instance.healthFinTxt = healthFinTxt;
        UIManager.Instance.scoreTotalTxt = totalScoreTxt;
        UIManager.Instance.endStateTxt = resultTxt;
        GameManager.Instance.putResultToEndScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
