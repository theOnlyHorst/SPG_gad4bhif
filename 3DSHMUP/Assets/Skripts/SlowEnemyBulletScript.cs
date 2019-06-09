using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyBulletScript : MonoBehaviour
{
    [SerializeField]
    private BulletStats stats;

    public float bulletDespawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
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
