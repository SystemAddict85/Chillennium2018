using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpStartingPosition : MonoBehaviour {

    private WarpTile tile;
    public enum PlayerPosition { PLAYER_ONE, PLAYER_TWO };

    public PlayerPosition playerStartingPos = PlayerPosition.PLAYER_ONE;

    private void Awake()
    {
        tile = GetComponentInParent<WarpTile>();
    }
	
}
