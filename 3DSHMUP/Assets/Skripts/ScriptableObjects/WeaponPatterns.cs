using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WeaponPatterns", menuName = "3DSHMUP/WeaponPatterns", order = 0)]
public class WeaponPatterns : ScriptableObject {
    
    [SerializeField]
    public PlayerGunPattern gunPattern;

    [SerializeField]
    public PlayerTripleGunPattern tripleGunPattern;

    
    [SerializeField]
    public PlayerShotGunPattern shotgunPattern;
    
    [SerializeField]
    public PlayerAutomaticPattern automaticPattern;
    
    [SerializeField]
    public PlayerAutomaticTriplePattern tripleAutomaticPattern;

    

    private void OnEnable() {
    }

    
}
[Serializable]
public class PlayerGunPattern
{
    [SerializeField]
    private float shootFrequency;
    [SerializeField]
    private GameObject shotPrefab;

    public float despawnTime;
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
[Serializable]
public class PlayerTripleGunPattern
{
    [SerializeField]
    private float shootFrequency;
    [SerializeField]
    private GameObject shotPrefab;

    public float despawnTime;
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
[Serializable]
public class PlayerShotGunPattern
{
    [SerializeField]
    private float shootFrequency;
    [SerializeField]
    private GameObject shotPrefab;

    public float despawnTime;
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
[Serializable]
public class PlayerAutomaticPattern
{
    [SerializeField]
    private float shootFrequency;
    [SerializeField]
    private GameObject shotPrefab;

    public float despawnTime;
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
[Serializable]
public class PlayerAutomaticTriplePattern
{
    [SerializeField]
    private float shootFrequency;
    [SerializeField]
    private GameObject shotPrefab;

    public float despawnTime;
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

