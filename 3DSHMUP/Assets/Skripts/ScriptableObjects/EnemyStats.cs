using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "3DSHMUP/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField]
    private List<SimpleEnemyStats> simpleEnemyStats;

    private Dictionary<SimpleEnemyDifficulty,SimpleEnemyStats> simpleEnemyDict;

    private void OnEnable() {
        simpleEnemyDict = new Dictionary<SimpleEnemyDifficulty,SimpleEnemyStats>();
        foreach(var e in simpleEnemyStats)
        {
            simpleEnemyDict.Add(e.diffculty,e);
        }
    }

    public SimpleEnemyStats GetSimpleEnemyStats(SimpleEnemyDifficulty diffculty)
    {
        return simpleEnemyDict[diffculty];
    }

}
[Serializable]
public class SimpleEnemyStats
{
    public string name;
    public SimpleEnemyDifficulty diffculty;
    public float movementSpeed;
    public float waitingTimeMovement;
    public GameObject shotPattern;
    public float shotFrequency;
    public int health;
}
public enum SimpleEnemyDifficulty
{
    EASY,
    MEDIUM,
    HARD
}