using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "3DSHMUP/BulletStats")]
public class BulletStats : ScriptableObject
{
    [SerializeField]
    public float slowBulletSpeed;
    [SerializeField]
    public float normalBulletSpeed;
    [SerializeField]
    public float fastBulletSpeed;


}

