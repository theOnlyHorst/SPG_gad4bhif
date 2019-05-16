using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormalScript : MonoBehaviour
{
    [SerializeField]
    private BulletStats stats;

    public float BulletDespawnTimer {
        set;get;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(BulletDespawnTimer<=0)
            Destroy(this.gameObject);
        else
        {
            BulletDespawnTimer-= Time.fixedDeltaTime;
        }
         
        Vector3 velocity = transform.up*stats.normalBulletSpeed*Time.fixedDeltaTime;
        transform.position += velocity;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "DestroyZone")
        {
            Destroy(this.gameObject);
        }
    }
}
