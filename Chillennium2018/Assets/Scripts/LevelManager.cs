using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour
{
    private bool canWarp = true;

    public int totalNumberOfRooms = 5;

    public int roomsVisited = 0;

    public Room[,] rooms;
    Vector2Int playerCoords;

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    public Room GetRoom { get { return rooms[playerCoords.x, playerCoords.y]; } }

    private Room previousRoomToAnimate;

    [HideInInspector]
    public bool isAPlayerDead = false;

    private Vector2 currentSpawnPos = new Vector2(0f, 0.5f);

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this);
        }

        rooms = new Room[totalNumberOfRooms, totalNumberOfRooms];
        int coord = (totalNumberOfRooms - 1) / 2;
        playerCoords = new Vector2Int(coord, coord);
        InitializeRoom(playerCoords);
    }

    private void InitializeRoom(Vector2Int coords, bool moveRoom = false, WarpTile.WarpDirection warpDir = WarpTile.WarpDirection.DOWN)
    {
        var roomGo = Instantiate(Resources.Load("Prefabs/Tilemap"), currentSpawnPos, Quaternion.identity, transform) as GameObject;
        var room = roomGo.GetComponent<Room>();

        previousRoomToAnimate = rooms[playerCoords.x, playerCoords.y];        
        rooms[coords.x, coords.y] = room;
        playerCoords = coords;

        if (moveRoom)
        {
            MoveRooms(warpDir);
        }

        roomsVisited++;
    }
    
    private void MoveRooms(WarpTile.WarpDirection warpDir)
    {

        string direction = "";
        switch (warpDir)
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
            default:
                direction = "";
                break;
        }
        if (direction != "")
        {
            previousRoomToAnimate.StartAnimation(direction);
            rooms[playerCoords.x, playerCoords.y].StartAnimation(direction);
        }
    }

    IEnumerator WaitToWarp()
    {
        yield return new WaitForSeconds(2f);
        canWarp = true;
    }

    public void Warp(WarpTile.WarpDirection warpDir)
    {
        if (canWarp)
        {
            GlobalStuff.PauseGame();
            HidePlayers();
            canWarp = false;
            var newCoords = CheckRoomCoords(warpDir);
            Debug.Log(newCoords + " new : old =" + playerCoords);
            if (newCoords != playerCoords)
            {
                InitializeRoom(newCoords, true);
            }            
        }
    }

    public bool CheckRoomVisit()
    {
        return true;
    }

    private Vector2Int CheckRoomCoords(WarpTile.WarpDirection warpDir)
    {
        Vector2Int addVec = new Vector2Int(0, 0);
        Vector2 spawnPos = Vector2.zero;
        switch (warpDir)
        {
            case WarpTile.WarpDirection.LEFT:
                addVec = new Vector2Int(-1, 0);
                spawnPos.x = -17;
                break;
            case WarpTile.WarpDirection.RIGHT:
                addVec = new Vector2Int(1, 0);
                spawnPos.x = 17;
                break;
            case WarpTile.WarpDirection.UP:
                addVec = new Vector2Int(0, 1);
                spawnPos.y = 11.5f;
                break;
            case WarpTile.WarpDirection.DOWN:
                addVec = new Vector2Int(0, -1);
                spawnPos.y = -11.5f;
                break;
        }
        Vector2Int resultVec = playerCoords + addVec;

        if ((resultVec.x >= 0 && resultVec.x < rooms.GetLength(0) - 1) && (resultVec.y >= 0 && resultVec.y < rooms.GetLength(1) - 1))
        {
            currentSpawnPos += spawnPos;
            return resultVec;
        }
        else
        {
            return new Vector2Int(0, 0);
        }
    }

    private void HidePlayers()
    {
        var players = FindObjectsOfType<Player>();
        foreach(var p in players)
        {
            p.HidePlayer();
        }
    }

    private void ShowPlayers()
    {
        var players = FindObjectsOfType<Player>();
        foreach (var p in players)
        {
            p.ShowPlayer();
        }
    }


    public void ClearRoom()
    {
        canWarp = true;
        //insert logic to show exits
    }
}
