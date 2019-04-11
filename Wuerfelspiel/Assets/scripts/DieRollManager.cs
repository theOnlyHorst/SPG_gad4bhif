using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieRollManager : MonoBehaviour
{
    private Rigidbody _rigid;

    private static int[] sidesXRot = {6,3,1,4};
    private static int[] sidesZRot = {6,2,1,5};
    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

}
