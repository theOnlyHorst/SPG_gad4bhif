using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private BulletStats stats;

    public float bulletDespawnTimer;
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
         
        Vector3 velocity = transform.forward*stats.normalBulletSpeed*Time.fixedDeltaTime;
        transform.position += velocity;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
