using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieRollManager : MonoBehaviour
{

    private bool idSet;

    private int id = 1;

    public int Id {
        get{
            return id;
        }
        set
        {
            if(!idSet)
            {
                id = value;
                idSet = true;
            }
        }
    }
    private Rigidbody _rigid;

    private RollDie _roller;
    private static Vector3 up = Vector3.up;

    private Vector3 evaluatedRotation;
    private static int[] sidesXRot = {6,3,1,4};
    private static int[] sidesZRot = {6,2,1,5};

    [SerializeField]
    private UnityEvent onDieRollEvaluated;

    private int score;

    public int Score {
        get{
            return score;
        }
    }

    private Dictionary<Vector3, int> lookup;
    // Start is called before the first frame update
    void Start()
    {
        _roller = GameObject.Find("DiceRoller").GetComponent<RollDie>();

        Vector3 vel = new Vector3(Random.Range(-0.2f,0.2f),Random.Range(9,15),Random.Range(-13,-15));
        Vector3 angVel = new Vector3(Random.value*5,Random.value*5,Random.value*5);
        _rigid = GetComponent<Rigidbody>();
        _rigid.velocity = vel;
        _rigid.rotation = Random.rotation;
        _rigid.angularVelocity = angVel;

        Debug.Log("Velocity: ");
        Debug.Log(vel);
        Debug.Log("Angular Velocity: ");
        Debug.Log(angVel);

        lookup = new Dictionary<Vector3, int>();
        lookup[Vector3.up] = 6;
        lookup[Vector3.right] = 2;
        lookup[Vector3.down] = 1;
        lookup[Vector3.left] = 5;
        lookup[Vector3.forward] = 4;
        lookup[Vector3.back] = 3;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(_rigid.IsSleeping())
        {
            if(!transform.rotation.Equals(evaluatedRotation))
            {
                score = getNumber(up);
                sendScore();
            }
        }
        Debug.Log(Score);
    }

    public int getNumber(Vector3 referenceVectorUp, float epsilonDeg = 5f) {
    
        Vector3 referenceObjectSpace = transform.InverseTransformDirection(referenceVectorUp);
 
        // Find smallest difference to object space direction
        float min = float.MaxValue;
        Vector3 minKey =new Vector3();
        foreach (Vector3 key in lookup.Keys) {
            float a = Vector3.Angle(referenceObjectSpace, key);
                if (a <= epsilonDeg && a < min) {
                    min = a;
                    minKey = key;
                }
        }
        return (min < epsilonDeg) ? lookup[minKey] : -1; // -1 as error code for not within bounds
    }

    private void sendScore()
    {
        _roller.UpdateDiceScore(id,score);
    }

}
