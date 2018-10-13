using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    private bool canWarp = false;

    public int totalNumberOfRooms = 5;

    public Room[,] rooms;
    Vector2Int playerCoords;

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }   

    void Awake(){
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(this);
        }

        rooms = new Room[totalNumberOfRooms, totalNumberOfRooms];
        int coord = totalNumberOfRooms - 1 / 2;
        playerCoords = new Vector2Int(coord, coord);
    }    

    public void Warp(WarpTile.WarpDirection warpDir)
    {
        if (canWarp)
        {
            // instantiate new tilemap
            // warp
        }
    }

    public bool CheckRoomVisit()
    {
        return true;
    }

    private Vector2Int CheckRoomCoords(WarpTile.WarpDirection warpDir)
    {
        Vector2Int addVec = new Vector2Int(0,0);
        switch (warpDir)
        {
            case WarpTile.WarpDirection.LEFT:
                addVec = new Vector2Int(-1, 0);
                break;
            case WarpTile.WarpDirection.RIGHT:
                addVec = new Vector2Int(1, 0);
                break;
            case WarpTile.WarpDirection.UP:
                addVec = new Vector2Int(0,1);
                break;
            case WarpTile.WarpDirection.DOWN:
                addVec = new Vector2Int(0,-1);
                break;
        }
        Vector2Int resultVec = playerCoords + addVec;
        if ((resultVec.x >= 0 && resultVec.x < rooms.GetLength(0) - 1) && (resultVec.y >= 0 && resultVec.y < rooms.GetLength(1) - 1))
            return resultVec;
        else
            return new Vector2Int(0, 0);
    }
}

public class Room : MonoBehaviour
{
    public bool isVisited = false;
    int roomId;
    List<Enemy> enemies = new List<Enemy>();


}
