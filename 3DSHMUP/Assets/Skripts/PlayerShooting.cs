using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private bool shootSw;

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
    }

    private void FixedUpdate() {
        if(shootSw)
        {
            GameObject shotPattern;
            float frequency;
            if(activeWeapon == WeaponType.TRIPLEGUN)
            {
                shotPattern = weaponPatterns.tripleGunPattern.ShotPrefab;
                frequency = weaponPatterns.tripleGunPattern.ShootFrequency;
            }
            //TODO other cases
            else
            {
                shotPattern = weaponPatterns.gunPattern.ShotPrefab;
                frequency = weaponPatterns.gunPattern.ShootFrequency;
            }

            if(cooldown<=0)
            {
                GameObject.Instantiate(shotPattern,transform.position+new Vector3(0,0,2),shotPattern.transform.rotation);
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
