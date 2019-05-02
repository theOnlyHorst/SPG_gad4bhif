using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayScore(int score)
    {
        _text.text = score.ToString();
    }
}
