using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RollDie : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;

    [SerializeField]
    private UnityEvent onScoreUpdated;
    private bool rollSw;

    private ScoreBoard _scoreBoard;

    private Dictionary<int,int> scores;

    private int diceCounter = 1;

    public int summedScore {
        get{
            int tmp =0;
            foreach(int sc  in scores.Values)
            {
                tmp+=sc;
            }
            return tmp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scores = new Dictionary<int,int>();
        _scoreBoard = GameObject.Find("Overall Score").GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Roll")) rollSw = true;
    }

    void FixedUpdate()
    {
        if(rollSw)
        {
            var copy = GameObject.Instantiate(dice);
            copy.transform.position = transform.position;
            diceCounter++;
            scores[diceCounter] = 0;
            copy.GetComponent<DieRollManager>().Id = diceCounter;
            rollSw =false;
        }
    }

    public void UpdateDiceScore(int id, int score)
    {
        scores[id] = score;
        _scoreBoard.displayScore(summedScore);
    }
}
