using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "3DSHMUP/LevelSpawns")]
public class LevelSpawns : ScriptableObject
{
    public List<SimpleEnemyDifficulty> enemySpawnsLV1;
    public List<int> enemyWavesLV1;


    public GameObject EnemyEasyPrefab;

    public GameObject EnemyMediumPrefab;

    public GameObject EnemyHardPrefab;
}
