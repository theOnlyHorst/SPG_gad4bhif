using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormalScript : MonoBehaviour
{
    [SerializeField]
    private BulletStats stats;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector3 velocity = transform.up;
        velocity = velocity*stats.normalBulletSpeed*Time.fixedDeltaTime;
        transform.position += velocity;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "DestroyZone")
        {
            Destroy(this.gameObject);
        }
    }
}
