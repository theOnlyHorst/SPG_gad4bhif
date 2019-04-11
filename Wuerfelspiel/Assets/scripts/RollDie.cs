using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDie : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;
    private bool rollSw;
    // Start is called before the first frame update
    void Start()
    {
        
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
            rollSw =false;
        }
    }
}
