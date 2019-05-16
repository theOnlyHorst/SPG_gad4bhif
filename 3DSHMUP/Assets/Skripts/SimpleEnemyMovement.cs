using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats;

    [SerializeField]
    private SimpleEnemyDifficulty difficulty;

    private SimpleEnemyStats stats;

    private Vector3 targetPos;

    private bool posReached;

    private float cooldownTime;

    private Vector3 referencePos;

    private float movementEpsilon = 0.4f;

    private GameManager gmInstance;

    
    // Start is called before the first frame update
    void Start()
    {
        gmInstance = GameManager.Instance;
        stats = enemyStats.GetSimpleEnemyStats(difficulty);
        referencePos = GameObject.FindGameObjectWithTag("EnemyReferencePoint").transform.position ;
        targetPos = referencePos + new Vector3(Random.Range(gmInstance.LowerScreenBounds.x+gmInstance.ScreenBoundsMargin,gmInstance.UpperScreenBounds.x-gmInstance.ScreenBoundsMargin),0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
        if(!posReached)
        {
            var path = targetPos-transform.position;
            if(path.magnitude<=movementEpsilon)
            {
                posReached = true;
                cooldownTime = stats.waitingTimeMovement;
            }
            else
            {
                if(path.magnitude>1)
                    path.Normalize();
                var velocity = path * stats.movementSpeed * Time.fixedDeltaTime;

                transform.position += velocity;
            }
        }
        else
        {
            if(cooldownTime<=0)
            {
                targetPos = referencePos + new Vector3(Random.Range(gmInstance.LowerScreenBounds.x+gmInstance.ScreenBoundsMargin,gmInstance.UpperScreenBounds.x-gmInstance.ScreenBoundsMargin),0,Random.Range(-1,1));
                posReached = false;
            }
            else
            {
                cooldownTime -= Time.fixedDeltaTime;
            }
        }
    }
}
