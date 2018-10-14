using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnInterval;
    private bool isReadyToSpawn = false;
    private float currentTime;
    private Room room;
    private BoxCollider2D boxCollider2D;


    [SerializeField]
    private int initialSpawnAmount = 0;

    private string[] allEnemyNames= {"Ground Enemy", "Lightning Enemy", "Water Enemy"};

    [SerializeField]
    private string[] enemyNames;
    private Queue<string> enemyNamesToSpawn = new Queue<string>();
    
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        if(enemyNames.Length == 0)
        {
            Debug.Log("Put enemy names into array");
            for (int i = 0; i < 10; i++)
            {
                int index = (int)Random.Range(0f, (float)allEnemyNames.Length);
                enemyNamesToSpawn.Enqueue(allEnemyNames[index]);
            }
        }
        else
        {
            foreach(var e in enemyNames)
            {
                enemyNamesToSpawn.Enqueue(e);
            }
        }
    }

    private void Start()
    {
        room = LevelManager.Instance.GetRoom;
        Initialize();
    }

    void Update()
    {
        CheckForSpawn();
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
                if (enemyNamesToSpawn.Count == 0) {
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
        Debug.Log("spawning " + enemyName + " at: " + pos);
        var enemy = Instantiate(Resources.Load("Prefabs/" + enemyName), pos, Quaternion.identity) as Enemy;
        room.AddEnemy(enemy);
    }

    private void Initialize()
    {
        isReadyToSpawn = false;
        currentTime = 0;
        InitialSpawn();
    }

    private void InitialSpawn()
    {
        for(int i = 0; i < initialSpawnAmount; ++i)
        {
            var enemyToSpawn = enemyNamesToSpawn.Dequeue();
            Debug.Log("dequeued: " + enemyToSpawn);
            Spawn(SpawnBounds(), enemyToSpawn);

            if (enemyNamesToSpawn.Count == 0)
            {
                isReadyToSpawn = false;                
                break;
            }
        }
        isReadyToSpawn = true;
    }

    
}
