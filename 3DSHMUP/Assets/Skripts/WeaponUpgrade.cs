using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private WeaponType weapon;

    private float despawnTime = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        despawnTime-=Time.deltaTime;
        if(despawnTime<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetWeapon(WeaponType type)
    {
        weapon = type;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerShooting>().SwitchWeapon(weapon);
            Destroy(this.gameObject);

        }
    }
}
