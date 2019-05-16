using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyShooting : MonoBehaviour
{

    [SerializeField]
    private EnemyStats enemyStats;

    [SerializeField]
    private SimpleEnemyDifficulty difficulty;

    private SimpleEnemyStats stats;

    private GameManager gmInstance;

    private float cooldown;

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        stats = enemyStats.GetSimpleEnemyStats(difficulty);
        cooldown = 5+1/stats.shotFrequency;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
    }
}
