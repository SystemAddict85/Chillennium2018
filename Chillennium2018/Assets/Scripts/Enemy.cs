using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character  {
    private void Awake()
    {
        maxHealth = 10f;
        currentHealth = maxHealth;
    }

    public override void Die()
    {
        float chanceToDrop = Random.Range(0f, 1f);
        chanceToDrop *= 100f;
        if (chanceToDrop <= 8f)//powerup
        {
            Debug.Log("todo: drop powerup");
        }
        else if (chanceToDrop >= 8f && chanceToDrop <= 20f)//health
        {
            Debug.Log("todo: drop Health");
        }
        else if (chanceToDrop >= 20f && chanceToDrop <= 24f && LevelManager.Instance.isAPlayerDead)
        {//revive
            Debug.Log("todo: drop Revive");
        }

        LevelManager.Instance.GetRoom.RemoveEnemyAndCheckForRoomComplete(this);
        base.Die();
    }

}
