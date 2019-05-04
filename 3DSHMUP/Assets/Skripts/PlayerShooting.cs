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
            bool exists= weaponPatterns.patternDict.TryGetValue(activeWeapon,out PlayerWeaponPattern pattern);
            if(!exists)
                return;
            if(cooldown<=0&&(pattern.automatic||shootDownSw))
            {
                foreach (Transform child in pattern.ShotPrefab.transform)
                {
                    var copy = Instantiate(child,transform.position+child.localPosition,child.rotation);
                    copy.GetComponent<BulletNormalScript>().BulletDespawnTimer = pattern.despawnTime;
                }
                cooldown = 1/pattern.ShootFrequency;
            }
            shootSw = false;
            shootDownSw = false;
        }
        cooldown -= Time.fixedDeltaTime;
    }

    
}
public enum WeaponType
{
    GUN,
    TRIPLEGUN,
    SHOTGUN,
    AUTOMATIC,
    TRIPLEAUTOMATIC,

}