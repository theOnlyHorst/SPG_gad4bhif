using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderScript : MonoBehaviour {
    

    private Collider2D col;
    private ScoreTracker sc;
    private Rigidbody2D ballRig;
    
    [SerializeField]
    private bool debugInfiniteLives;

	// Use this for initialization
	void Start () {
        col = GetComponent<Collider2D>();
        sc = GameObject.Find("GameManager").GetComponent<ScoreTracker>();
        ballRig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (sc.lives == 0&&!debugInfiniteLives)
            {
                 SceneManager.LoadScene("EndScene");

            }
            else
            {
                sc.loseLive();
                collision.gameObject.transform.position = new Vector2(0, -4.05f);
                var bc = collision.gameObject.GetComponent<BallCharge>();
                if(bc.chargeEnabled)
                {
                    bc.chargeEnd();
                }
                ballRig.velocity = new Vector2(0, 0);

                ballRig.velocity = new Vector2(Random.value <= 0.5 ? -5 : 5, 3);
            }

            
        }



    }
}
