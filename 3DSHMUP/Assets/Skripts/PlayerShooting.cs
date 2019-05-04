using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private bool shootSw;

    private bool shootDownSw;
    
    
    [SerializeField]
    private WeaponPatterns weaponPatterns;

    private float cooldown;

    [SerializeField]
    private WeaponType activeWeapon = WeaponType.GUN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("shoot")) shootSw = true;
        if(Input.GetButtonDown("shoot")) shootDownSw = true;
    }

    private void FixedUpdate() {
        if(shootSw)
        {
            GameObject shotPattern = null;
            float frequency = 0;
            float despawnTimer = 0;
            if(activeWeapon == WeaponType.TRIPLEGUN&&shootDownSw)
            {
                shotPattern = weaponPatterns.tripleGunPattern.ShotPrefab;
                frequency = weaponPatterns.tripleGunPattern.ShootFrequency;
                despawnTimer = weaponPatterns.tripleGunPattern.despawnTime;
            }
            //TODO other cases
            else if(shootDownSw)
            {
                shotPattern = weaponPatterns.gunPattern.ShotPrefab;
                frequency = weaponPatterns.gunPattern.ShootFrequency;
                despawnTimer = weaponPatterns.gunPattern.despawnTime;
            }

            if(shotPattern!=null&&cooldown<=0)
            {
                foreach (Transform child in shotPattern.transform)
                {
                    var copy = Instantiate(child,transform.position+new Vector3(0,0,3)+child.localPosition,child.rotation);
                    copy.GetComponent<BulletNormalScript>().BulletDespawnTimer = despawnTimer;
                }
                cooldown = 1/frequency;
            }
            shootSw = false;
        }
        cooldown -= Time.fixedDeltaTime;
    }

    public enum WeaponType
    {
        GUN,
        TRIPLEGUN,
        SHOTGUN,
        AUTOMATIC,
        TRIPLEAUTOMATIC,

    }
}
