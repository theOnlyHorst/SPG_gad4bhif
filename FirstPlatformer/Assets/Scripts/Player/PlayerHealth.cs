using Prime31;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int startHealth;

    [SerializeField]
    private float colorSwitchSecondsDelayMax;

    [SerializeField]
    private float iFramesHit;

    [SerializeField]
    private float iFramesFall;

    private float colorSwitchSecondsDelay;

    private int health;

    private float invincibility;

    private SpriteRenderer sprRender;

    private CharacterController2D contr;

    [SerializeField]
    private UnityEvent onHealthChanged;

    private PlayerMovementV2 mv;

	// Use this for initialization
	void Start () {
        health = startHealth;
        sprRender = GetComponentInChildren<SpriteRenderer>();
        mv = GetComponent<PlayerMovementV2>();
        contr = GetComponent<CharacterController2D>();
        contr.onControllerCollidedEvent += on2DControllerColliderHit;
	}
	
	// Update is called once per frame
	void Update () {
        if (invincibility > 0)
        {
            if (colorSwitchSecondsDelay <= 0)
            {
                if (sprRender.color.a == 1)
                {
                    sprRender.color = new Color(1, 1, 1, 0.6f);
                }
                else
                {
                    sprRender.color = new Color(1, 1, 1, 1);
                }
                colorSwitchSecondsDelay = colorSwitchSecondsDelayMax;
                
            }
            else
            {
                colorSwitchSecondsDelay -= Time.deltaTime;
            }
            invincibility -= Time.deltaTime;
        }
        else
        {
            if (sprRender.color.a != 1)
            {
                sprRender.color = new Color(1, 1, 1, 1);
            }
        }
        
	}



    private void on2DControllerColliderHit(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.CompareTag("Damaging") && invincibility <= 0)
        {
            invincibility = iFramesHit;
           // mv.PlayerKnockback();
            CheckGameOver();
            health--;
            onHealthChanged.Invoke();
        }
    }


    public void respawnDamage()
    {
        health--;
        CheckGameOver();
        invincibility = iFramesFall;
        onHealthChanged.Invoke();
    }

    public void AddHealth(int health)
    {
        this.health += health;
        onHealthChanged.Invoke();
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetStartHealth()
    {
        return startHealth;
    }

    private void CheckGameOver()
    {
        if(health==0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
