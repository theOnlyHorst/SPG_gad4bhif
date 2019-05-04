using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WeaponPatterns", menuName = "3DSHMUP/WeaponPatterns", order = 0)]
public class WeaponPatterns : ScriptableObject {

    
    //Maybe use this in future
    [SerializeField]
    private List<PlayerWeaponPattern> patterns;
    

    public Dictionary<WeaponType,PlayerWeaponPattern> patternDict;

    private void OnEnable() {
        patternDict = new Dictionary<WeaponType,PlayerWeaponPattern>();
        foreach(var p in patterns)
        {
            patternDict.Add(p.WeaponType,p);
        }
    }

    
}
[Serializable]
public class PlayerWeaponPattern
{
    [SerializeField]
    private string name;

    public WeaponType WeaponType;
    [SerializeField]
    private float shootFrequency;
    [SerializeField]
    private GameObject shotPrefab;

    public float despawnTime;

    public bool automatic;
    public float ShootFrequency{
        get
        {
            return shootFrequency;
        }
    }

    public GameObject ShotPrefab{
        get
        {
            return shotPrefab;
        }
    }
}


