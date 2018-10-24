using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTargets : MonoBehaviour {
    [SerializeField]
    private GameObject template;

    private List<GameObject> targetList;

    private ScoreTracker sc;
	// Use this for initialization
	void Start () {
        sc = GameObject.Find("GameManager").GetComponent<ScoreTracker>();
        targetList = new List<GameObject>();
        for(int i = -17;i<19;i++)
        {
            var copy = Instantiate(template);
            copy.transform.position = new Vector2(0.48f*i-0.33f, 1.6f);
            copy.GetComponent<TargetDisappear>().scoreRewarded = 10;
            sc.targetCount++;
            targetList.Add(copy);
        }
        for (int i = -17; i < 19; i++)
        {
            var copy = Instantiate(template);
            copy.transform.position = new Vector2(0.48f * i - 0.33f, 2.07f);
            copy.GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.95f, 0.188f,1f);
            copy.GetComponent<TargetDisappear>().scoreRewarded = 20;
            sc.targetCount++;
            targetList.Add(copy);

        }
        for (int i = -17; i < 19; i++)
        {
            var copy = Instantiate(template);
            copy.transform.position = new Vector2(0.48f * i - 0.33f, 2.54f);
            copy.GetComponent<SpriteRenderer>().color = new Color(0.96f,0.956f,0.25f);
            copy.GetComponent<TargetDisappear>().scoreRewarded = 30;
            sc.targetCount++;
            targetList.Add(copy);

        }
        for (int i = -17; i < 19; i++)
        {
            var copy = Instantiate(template);
            copy.transform.position = new Vector2(0.48f * i - 0.33f, 3.01f);
            copy.GetComponent<TargetDisappear>().scoreRewarded = 40;
            copy.GetComponent<SpriteRenderer>().color = new Color(0.898f, 0.552f, 0.188f);
            sc.targetCount++;
            targetList.Add(copy);

        }
        for (int i = -17; i < 19; i++)
        {
            var copy = Instantiate(template);
            copy.transform.position = new Vector2(0.48f * i - 0.33f, 3.48f);
            copy.GetComponent<TargetDisappear>().scoreRewarded = 50;
            copy.GetComponent<SpriteRenderer>().color = new Color(0.847f, 0.156f, 0.05f);
            sc.targetCount++;
            targetList.Add(copy);

        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<BallCharge>().targetCollsLoad(targetList);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
