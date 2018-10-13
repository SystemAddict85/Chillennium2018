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
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LevelManager.Instance.Warp(warpDir);
        }
    }

}
