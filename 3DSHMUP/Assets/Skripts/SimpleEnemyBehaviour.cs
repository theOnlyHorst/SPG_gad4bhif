using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats;

    [SerializeField]
    private SimpleEnemyDifficulty difficulty;

    private int currentHealth;

    private float cooldownShot;

    private Transform playerTransform;

    private Vector3 targetPos;

    private bool posReached;

    private float cooldownMove;

    private Vector3 referencePos;

    private GameManager gmInstance;

    private float movementEpsilon = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        gmInstance = GameManager.Instance;
        currentHealth = enemyStats.GetSimpleEnemyStats(difficulty).health;
        cooldownShot = 2+1/enemyStats.GetSimpleEnemyStats(difficulty).shotFrequency;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        referencePos = GameObject.FindGameObjectWithTag("EnemyReferencePoint").transform.position ;
        targetPos = referencePos + new Vector3(Random.Range(gmInstance.LowerScreenBounds.x+gmInstance.ScreenBoundsMargin,gmInstance.UpperScreenBounds.x-gmInstance.ScreenBoundsMargin),0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(cooldownShot<=0)
        {
            Vector3 shotDirRaw = (playerTransform.position-transform.position);
            shotDirRaw.y = 0;
            var shotDir = shotDirRaw.normalized;

            var pattern = Random.value < enemyStats.GetSimpleEnemyStats(difficulty).secondaryChance?enemyStats.GetSimpleEnemyStats(difficulty).secondaryShotPattern:enemyStats.GetSimpleEnemyStats(difficulty).primaryShotPattern;

            var shot = Instantiate(pattern,transform.position,Quaternion.LookRotation(shotDir));
            cooldownShot = 1/enemyStats.GetSimpleEnemyStats(difficulty).shotFrequency;

        }else
        {
            cooldownShot -= Time.fixedDeltaTime;
        }

        if(!posReached)
        {
            var path = targetPos-transform.position;
            if(path.magnitude<=movementEpsilon)
            {
                posReached = true;
                cooldownMove = enemyStats.GetSimpleEnemyStats(difficulty).waitingTimeMovement;
            }
            else
            {
                if(path.magnitude>1)
                    path.Normalize();
                var velocity = path * enemyStats.GetSimpleEnemyStats(difficulty).movementSpeed * Time.fixedDeltaTime;

                transform.position += velocity;
            }
        }
        else
        {
            if(cooldownMove<=0)
            {
                targetPos = referencePos + new Vector3(Random.Range(gmInstance.LowerScreenBounds.x+gmInstance.ScreenBoundsMargin,gmInstance.UpperScreenBounds.x-gmInstance.ScreenBoundsMargin),0,Random.Range(-1,1));
                posReached = false;
            }
            else
            {
                cooldownMove -= Time.fixedDeltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Damaging Enemy")
        {
            currentHealth--;
            if(currentHealth==0)
            {
                gmInstance.PlayerAddScore(enemyStats.GetSimpleEnemyStats(difficulty).score);
                Destroy(this.gameObject);
                gmInstance.EnemyDeath();
            }
        }
    }
}
