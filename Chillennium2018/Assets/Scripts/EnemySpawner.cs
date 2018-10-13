using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnInterval;
    private bool isReadyToSpawn = false;
    private float currentTime;
    public GameObject enemy;
    private Room room;

    [SerializeField]
    private int initialSpawnAmount = 0;



    [SerializeField]
    private string[] enemyNames;
    private Queue<string> enemyNamesToSpawn = new Queue<string>();
    
    private void Awake()
    {
        if(enemyNames.Length == 0)
        {
            Debug.Log("Put enemy names into array");
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
        if (isReadyToSpawn)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= spawnInterval)
            {
                currentTime = 0;
                var enemyToSpawn = enemyNamesToSpawn.Dequeue();
                if (enemyNamesToSpawn.Count == 0) {
                    isReadyToSpawn = false;
                }
                Spawn(enemy.transform.position, enemyToSpawn);

            }
        }
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
            Spawn(enemy.transform.position, enemyToSpawn);

            if (enemyNamesToSpawn.Count == 0)
            {
                isReadyToSpawn = false;                
                break;
            }
        }
        isReadyToSpawn = true;
    }

    
}
