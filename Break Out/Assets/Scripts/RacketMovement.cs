using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

    private SpriteRenderer rend;

    [SerializeField]
    private KeyCode left, right, charge;

    private int chargeCount;
    private int prevCharge;
    private int coolDownCharge;
    private int prevCoolDown;
    [SerializeField]
    private int chargeMax, coolDownChargeMax;

    private bool leftSwitch, rightSwitch,chargeSw;


   
	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(left)) leftSwitch = true;
        if (Input.GetKey(right)) rightSwitch = true;
        if (Input.GetKey(charge)) chargeSw = true;
        if (chargeCount != prevCharge)
        {
            rend.color = Color.Lerp(Color.white, Color.red, (float)chargeCount/(float)chargeMax);
            prevCharge = chargeCount;
        }
        if(prevCoolDown != coolDownCharge)
        {
            rend.color = Color.Lerp(Color.white, Color.blue, (float)coolDownCharge / (float)coolDownChargeMax);
        }
        

	}

    private void FixedUpdate()
    {
        if(leftSwitch)
        {
            if (chargeSw && coolDownCharge == 0)
            {
                transform.Translate(new Vector2(0f, 0.05f));
                leftSwitch = false;
            }
            else
            {
                transform.Translate(new Vector2(0f, 0.1f));
                leftSwitch = false;
            }
        }
        if(rightSwitch)
        {
            if (chargeSw && coolDownCharge == 0)
            {
                transform.Translate(new Vector2(0f, -0.05f));
                rightSwitch = false;
            }
            else
            {
                transform.Translate(new Vector2(0f, -0.1f));
                rightSwitch = false;
            }
        }
        if(chargeSw&&coolDownCharge==0)
        {
            if(chargeCount<chargeMax)
            {
                chargeCount++;
                //Debug.Log(chargeCount.ToString());
            }
            else
            {
                
            }
            chargeSw = false;
        }
        else
        {
            if (chargeCount > 0)
            {
                chargeCount--;
                //Debug.Log(chargeCount.ToString());
            }
        }
        if(coolDownCharge>0)
        {
            coolDownCharge--;
            //Debug.Log(coolDownCharge.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
           
            if (chargeCount == chargeMax)
            {
                collision.gameObject.GetComponent<BallCharge>().ChargeTrigger();
                chargeCount = 0;
                coolDownCharge = coolDownChargeMax;
            }
           
        //}
    }
}
