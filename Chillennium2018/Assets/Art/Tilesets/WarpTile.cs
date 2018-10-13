using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WarpTile : MonoBehaviour {

    public enum WarpDirection { LEFT, RIGHT, UP, DOWN };

    [SerializeField]
    private WarpDirection warpDir;    

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

    private Vector2 GetPlayerStartingPosition(int playerNum)
    {
        playerNum -= 1;
        var playerPos = (WarpStartingPosition.PlayerPosition)playerNum;

        var starts = GetComponentsInChildren<WarpStartingPosition>();
        var pos = starts[0].playerStartingPos == playerPos ? starts[0].transform.position : starts[1].transform.position;
        return pos;
        
    }

}
