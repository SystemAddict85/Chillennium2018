using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    int roomId;
    List<Enemy> enemies = new List<Enemy>();
    public bool isRoomComplete = false;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemyAndCheckForRoomComplete(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            isRoomComplete = true;
            LevelManager.Instance.ClearRoom();
        }
    }
}