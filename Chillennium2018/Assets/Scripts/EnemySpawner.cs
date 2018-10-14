using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get { return _instance; } }

    public float spawnInterval;
    private bool isReadyToSpawn = false;
    private float currentTime;
    private BoxCollider2D boxCollider2D;

    private bool canSpawn = true;

    [SerializeField]
    private int initialSpawnAmount = 0;

    private string[] allEnemyNames = { "Ground Enemy", "Lightning Enemy", "Water Enemy" };

    [SerializeField]
    private string[] enemyNames;
    private Queue<string> enemyNamesToSpawn = new Queue<string>();

    [SerializeField]
    private int numNames = 10;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        InitializeQueue();
    }

    private void InitializeQueue()
    {
        if (enemyNames.Length == 0)
        {
            for (int i = 0; i < numNames; i++) // change 10 to howmany names we need I guess
            {
                int index = Random.Range(0, allEnemyNames.Length);
                enemyNamesToSpawn.Enqueue(allEnemyNames[index]);
            }
        }
        else
        {
            foreach (var e in enemyNames)
            {
                enemyNamesToSpawn.Enqueue(e);
            }
        }
    }

    private void Start()
    {
        boxCollider2D = LevelManager.Instance.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (canSpawn)
            CheckForSpawn();
    }

    public void ToggleSpawning(bool enabled)
    {
        canSpawn = enabled;
    }

    private void CheckForSpawn()
    {
        if (isReadyToSpawn && enemyNamesToSpawn.Count > 0)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= spawnInterval)
            {
                currentTime = 0;
                var enemyToSpawn = enemyNamesToSpawn.Dequeue();
                if (enemyNamesToSpawn.Count == 0)
                {
                    isReadyToSpawn = false;
                }


                Spawn(SpawnBounds(), enemyToSpawn);

            }
        }
    }

    private Vector2 SpawnBounds()
    {
        Vector2 spawnBounds = boxCollider2D.bounds.extents;
        spawnBounds.x = Random.Range(-spawnBounds.x, spawnBounds.x);
        spawnBounds.y = Random.Range(-spawnBounds.y, spawnBounds.y);
        return spawnBounds;
    }

    private void Spawn(Vector2 pos, string enemyName)
    {
        var enemyGo = Instantiate(Resources.Load("Prefabs/" + enemyName), pos, Quaternion.identity) as GameObject;
        var enemy = enemyGo.GetComponent<Enemy>();
        LevelManager.Instance.AddEnemy(enemy);
    }

    public void Initialize()
    {
        InitializeQueue();
        isReadyToSpawn = false;
        currentTime = 0f;
        isReadyToSpawn = true;
    }


}
