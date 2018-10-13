using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private bool canWarp = false;

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    [HideInInspector]
    public bool isAPlayerDead = false;

    void Awake(){
        if(_instance == null)
        {
            _instance = this;
        }else if(_instance != this)
        {
            Destroy(this);
        }
    }    

    public void Warp(WarpTile.WarpDirection warpDir)
    {
        if (canWarp)
        {
            //warp 
        }
    }
}
