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

    private float colorSwitchSecondsDelay;

    private int health;

    private float invincibility;

    private SpriteRenderer sprRender;

    [SerializeField]
    private UnityEvent onHealthChanged;

    private PlayerMovement mv;

	// Use this for initialization
	void Start () {
        health = startHealth;
        sprRender = GetComponentInChildren<SpriteRenderer>();
        mv = GetComponent<PlayerMovement>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damaging")&&invincibility<=0)
        {
            invincibility = 3f;
            mv.PlayerKnockback();
            CheckGameOver();
            health--;
            onHealthChanged.Invoke();
        }
    }

    public void respawnDamage()
    {
        health--;
        CheckGameOver();
        invincibility = 1f;
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
