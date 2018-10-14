using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character  {

    private int enemyStartingHealth;

    private void Awake()
    {
        maxHealth = enemyStartingHealth;
        currentHealth = maxHealth;
    }


    public override void Die()
    {
        Controller.ControllerType controllerType = passedController.playerNumber;
        ScoreManager.Instance.AddScore(controllerType);

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
        else if (chanceToDrop >= 20f && chanceToDrop <= 24f && LevelManager.Instance.isOnePlayerDead)
        {
            Debug.Log("todo: drop Revive");
        }

        LevelManager.Instance.RemoveEnemyAndCheckForRoomComplete(this);
        
    }

}
