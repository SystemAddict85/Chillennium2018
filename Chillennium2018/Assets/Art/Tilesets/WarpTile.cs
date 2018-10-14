using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WarpTile : MonoBehaviour {

    public enum WarpDirection { LEFT, RIGHT, UP, DOWN };
        
    public WarpDirection warpDir;

    public void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LevelManager.Instance.Warp(warpDir);
        }
    }

    public Vector2 GetPlayerStartingPosition(Controller.ControllerType controllerPlayer)
    {
        var playerPos = (WarpStartingPosition.PlayerPosition)controllerPlayer;
        var starts = GetComponentsInChildren<WarpStartingPosition>();
        var pos = starts[0].playerStartingPos == playerPos ? starts[0].transform.position : starts[1].transform.position;
        return pos;        
    }

    public static WarpDirection GetOppositeDirection(WarpDirection wDir)
    {
        WarpDirection w = WarpDirection.DOWN;
        switch (wDir)
        {
            case WarpDirection.LEFT:
                w = WarpDirection.RIGHT;
                break;
            case WarpDirection.RIGHT:
                w = WarpDirection.LEFT;
                break;
            case WarpDirection.UP:
                w = WarpDirection.DOWN;
                break;
            case WarpDirection.DOWN:
                w = WarpDirection.UP;
                break;
        }
        return w;
    }

}
