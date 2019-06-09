using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "3DSHMUP/GameManager")]
public class GameManager : ScriptableObject
{
    private static GameManager m_instance;
    public static GameManager Instance{
        get{return m_instance;}
    }

    [SerializeField]
    private Vector3 upperScreenBounds;

    [SerializeField]
    private Vector3 lowerScreenBounds;

    [SerializeField]
    private float screenBoundsMargin;

    [SerializeField]
    private int playerMaxHealth;

    [SerializeField]
    private LevelSpawns spawns;

    [SerializeField]
    private int healthBonus;

    private int currentHealth;

    private int score = 0;

    private Queue<SimpleEnemyDifficulty> enemySpawns;

    private Queue<int> waveSizes;

    private int activeWave;

    private bool won;

    public GameObject dropObj;


    [HideInInspector]
    public List<GameObject> spawnpoints;

    public int maxIFrames;

    public Vector3 UpperScreenBounds
    {
        get
        {
            return upperScreenBounds;
        }
    }

    public Vector3 LowerScreenBounds
    {
        get
        {
            return lowerScreenBounds;
        }
    }

    public float ScreenBoundsMargin
    {
        get
        {
            return screenBoundsMargin;
        }
    }
    void OnEnable()
    {
        if(m_instance == null)
            m_instance = this;
        else
            Debug.LogError("There may only be one GameManager!");
        spawnpoints = new List<GameObject>();
        
    }

    public void InitLevel()
    {
        score = 0;
        won = false;
        currentHealth = playerMaxHealth;
        UIManager.Instance.displayHealth(currentHealth);
        LoadLevelSpawns();
        NextWave();
    }


    public bool IsInBounds(Vector3 position)
    {
        return position.x>lowerScreenBounds.x&&position.x<upperScreenBounds.x&&position.z>lowerScreenBounds.z&&position.z<upperScreenBounds.z;
    }


    public void PlayerTakeDamage()
    {
        currentHealth--;
        if(currentHealth==0)
        {
            GameOver();
            return;
        }
        UIManager.Instance.displayHealth(currentHealth);
    }

    public void PlayerAddScore(int score)
    {
        Debug.Log(this.score);
        this.score+=score;
        Debug.Log(score);
        Debug.Log(this.score);
        UIManager.Instance.displayScore(this.score);
    }

    private void GameOver()
    {
        won = false;
        LoadEndScreen();
    }

    public void LoadLevelSpawns()
    {
        enemySpawns = new Queue<SimpleEnemyDifficulty>();
        foreach(var d in spawns.enemySpawnsLV1)
        {
            enemySpawns.Enqueue(d);
        }
        waveSizes = new Queue<int>();
        int validate = 0;
        foreach(var w in spawns.enemyWavesLV1)
        {
            validate+=w;
            waveSizes.Enqueue(w);
        }
        if(validate!=enemySpawns.Count)
        {
            Debug.LogError("Wave sizes do not mach enemy spawns");
        }
        activeWave = 0;
    }

    public void NextWave()
    {
        if(waveSizes.Count == 0)
        {
            won =true;
            LoadEndScreen();
            return;
        }
        activeWave = waveSizes.Dequeue();
        for(int i=0;i<activeWave;i++)
        {
            GameObject toSpawn;
            var spawn =  enemySpawns.Dequeue();
            if(spawn == SimpleEnemyDifficulty.EASY) 
                toSpawn = spawns.EnemyEasyPrefab;
            else if(spawn == SimpleEnemyDifficulty.MEDIUM)
                toSpawn = spawns.EnemyMediumPrefab;
            else
                toSpawn = spawns.EnemyHardPrefab;
            
            int spawnpointInd = Random.Range(0,spawnpoints.Count);
            Debug.Log(spawnpointInd);
            var sppoint = spawnpoints[spawnpointInd];

            Instantiate(toSpawn,sppoint.transform.position,toSpawn.transform.rotation);
        }
    }

    public void EnemyDeath()
    {
        activeWave--;
        if(activeWave==0)
        {
            PlayerAddScore(10);
            NextWave();
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void LoadEndScreen()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void putResultToEndScreen()
    {
        UIManager.Instance.displayResults(score,currentHealth,healthBonus,score+healthBonus*currentHealth,won);
    }

}
