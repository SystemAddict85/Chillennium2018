using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;

    private bool canWarp = true;

    public int roomsVisited = 0;

    private Room previousRoom;
    private Room currentRoom;

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    public Room GetRoom { get { return currentRoom; } }

    [HideInInspector]
    public bool isOnePlayerDead = false;

    private Vector2 currentSpawnPos = new Vector2(0f, 0.5f);

    private WarpTile.WarpDirection directionInTransit = WarpTile.WarpDirection.UP;
    private WarpTile.WarpDirection directionOfArrival;

    public Dictionary<WarpTile.WarpDirection, WarpTile> warpTiles = new Dictionary<WarpTile.WarpDirection, WarpTile>();

    public List<Enemy> currentRoomEnemies;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        foreach (var w in GetComponentsInChildren<WarpTile>())
        {
            warpTiles.Add(w.warpDir, w);
        }

        canWarp = false;
        FindPlayers();
    }
    private void Start()
    {
        InitializeRoom();
    }

    void FindPlayers()
    {
        foreach (var p in FindObjectsOfType<PlayerController>())
        {
            var player = p.GetComponent<Player>();
            if (p.playerNumber == Controller.ControllerType.PLAYER_ONE)
            {
                Player1 = player;
            }
            else
            {
                Player2 = player;
            }
        }
    }

    private void InitializeRoom(bool moveRoom = false)
    {
        if (previousRoom != null)
        {
            Destroy(previousRoom.gameObject);
        }

        Debug.Log("setting previous room to: " + currentRoom);
        previousRoom = currentRoom;

        var roomGo = Instantiate(Resources.Load("Prefabs/Room"), currentSpawnPos, Quaternion.identity, transform) as GameObject;
        currentSpawnPos = new Vector2(0, 0.5f);
        roomGo.name += roomsVisited;
        currentRoom = roomGo.GetComponent<Room>();
        currentRoomEnemies = new List<Enemy>();

        if (moveRoom)
        {
            MoveRooms();
            directionOfArrival = directionInTransit;
        }
        roomsVisited++;

        GlobalStuff.FreezeAllMovement();
        GlobalStuff.LoseAllControl();
        StartCoroutine(DelayBlockingExits());
    }

    private void MoveRooms()
    {
        string direction = "";
        switch (directionInTransit)
        {
            case WarpTile.WarpDirection.LEFT:
                direction = "right";
                break;
            case WarpTile.WarpDirection.RIGHT:
                direction = "left";
                break;
            case WarpTile.WarpDirection.UP:
                direction = "down";
                break;
            case WarpTile.WarpDirection.DOWN:
                direction = "up";
                break;
        }
        previousRoom.StartAnimation(direction);
        currentRoom.StartAnimation(direction);
    }

    public void StartWaitToWarp()
    {
        GlobalStuff.UnpauseGame();
        ShowAndTeleportPlayers();
        StartCoroutine(WaitToWarp());
    }

    IEnumerator WaitToWarp()
    {
        yield return new WaitForSeconds(3f);
        canWarp = true;
    }

    public void Warp(WarpTile.WarpDirection warpDir)
    {
        directionInTransit = warpDir;
        if (canWarp)
        {
            GlobalStuff.PauseGame();
            HidePlayers();
            canWarp = false;

            InitializeRoom(true);
        }
    }

    private void CheckRoomCoords(WarpTile.WarpDirection warpDir)
    {
        Vector2 spawnPos = Vector2.zero;
        switch (warpDir)
        {
            case WarpTile.WarpDirection.LEFT:
                spawnPos.x = -17;
                break;
            case WarpTile.WarpDirection.RIGHT:
                spawnPos.x = 17;
                break;
            case WarpTile.WarpDirection.UP:
                spawnPos.y = 11.5f;
                break;
            case WarpTile.WarpDirection.DOWN:
                spawnPos.y = -11.5f;
                break;
        }
        currentSpawnPos += spawnPos;

    }

    private void HidePlayers()
    {
        if (!Player1.isPlayerDead)
            Player1.HidePlayer();
        if (!Player2.isPlayerDead)
            Player2.HidePlayer();
    }

    private void ShowAndTeleportPlayers()
    {
        WarpTile.WarpDirection warp = WarpTile.GetOppositeDirection(directionInTransit);

        var room = GetRoom;

        if (!Player1.isPlayerDead)
        {
            Player1.transform.position = warpTiles[warp].GetPlayerStartingPosition(Player1.controller.playerNumber);
            Player1.ShowPlayer();
        }

        if (!Player2.isPlayerDead)
        {
            Player2.transform.position = warpTiles[warp].GetPlayerStartingPosition(Player2.controller.playerNumber);
            Player2.ShowPlayer();
        }
    }

    IEnumerator DelayBlockingExits()
    {
        yield return new WaitForSeconds(1f);
        BlockExits();
        GlobalStuff.UnfreezeAll();
        GlobalStuff.RegainAllControl();
        EnemySpawner.Instance.Initialize();
    }

    public void ClearRoom()
    {
        canWarp = true;
        UnblockAllButPreviousExit();
    }

    public void BlockExits()
    {
        foreach (var w in warpTiles.Values)
        {
            w.block.Block();
        }
    }

    public void UnblockAllButPreviousExit()
    {
        foreach (var w in warpTiles.Values)
        {
            if (w == warpTiles[directionOfArrival] && roomsVisited > 1)
            {
                w.block.Block();
            }
            else
            {
                w.block.Unblock();
            }
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        currentRoomEnemies.Add(enemy);
    }

    public void RemoveEnemyAndCheckForRoomComplete(Enemy enemy)
    {
        currentRoomEnemies.Remove(enemy);
        Destroy(enemy.gameObject);

        if (currentRoomEnemies.Count == 0)
        {
            currentRoom.isRoomComplete = true;
            ClearRoom();
        }
    }

}
