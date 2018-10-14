using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{    
    public bool isRoomComplete = false;        

    public void StartAnimation(string direction)
    {
        GetComponent<Animator>().SetTrigger(direction);
    }

    public void EndAnimation()
    {
        if (!isRoomComplete)
            LevelManager.Instance.StartWaitToWarp();
    }
}