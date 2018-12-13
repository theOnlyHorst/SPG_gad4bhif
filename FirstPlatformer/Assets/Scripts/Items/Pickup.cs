using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour {

    [SerializeField]
    private UnityEvent onPickup;

    [SerializeField]
    private PickupType type;

    [SerializeField]
    private int amount;

    [SerializeField]
    private bool respawning;

    [SerializeField]
    private float respawnTime;

    private float respawnCounter;

    private bool active;

    private SpriteRenderer spRend;
	// Use this for initialization
	void Start () {
        active = true;
        spRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(respawning)
        {
            if(respawnCounter >0)
            {
                respawnCounter -= Time.deltaTime;
            }
            else
            {
                active = true;
                spRend.color = new Color(1, 1, 1, 1);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            onPickup.Invoke();

            if (!respawning)
                Destroy(this.gameObject);
            else
            {
                respawnCounter = respawnTime;
                active = false;
                spRend.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
public enum PickupType
{
    Coin,
    Health,
    DoubleJump
}