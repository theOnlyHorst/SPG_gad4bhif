using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemyBulletScript : MonoBehaviour
{
    [SerializeField]
    private BulletStats stats;

    public float bulletDespawnTimer;

    [SerializeField]
    private float chaseTimer;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        
        if(bulletDespawnTimer<=0)
            Destroy(this.gameObject);
        else
        {
            bulletDespawnTimer-= Time.fixedDeltaTime;
        }
        if(chaseTimer>0)
        {
            var dir = (playerTransform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(dir);
            chaseTimer-=Time.fixedDeltaTime;
        }

            Vector3 velocity = transform.forward*stats.slowBulletSpeed*Time.fixedDeltaTime;
            transform.position += velocity;
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
