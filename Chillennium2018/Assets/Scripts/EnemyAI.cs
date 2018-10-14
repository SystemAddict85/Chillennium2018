using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private Player playerTarget;
    private Movement move;

    private bool canThink = false;
    
    private void Awake()
    {
        if (playerTarget == null)
        {
            FindNearestPlayer();
        }
        else
        {
            canThink = true;
        }
        move = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        if (canThink)
        {
            if (playerTarget && !playerTarget.isPlayerDead)
            {
                EnemyMove();
            }
            else
            {
                canThink = false;
                FindNearestPlayer();
            }
        }
    }

    private void FindNearestPlayer()
    {        
        Player closestPlayer = null;
        float closestDistance = float.MaxValue;

        var player1 = LevelManager.Instance.Player1;
        var player2 = LevelManager.Instance.Player2;

        if (!player1.isPlayerDead)
        {
            closestPlayer = player1;
            closestDistance = DistanceToPlayer(player1.transform);
        }
        var distToPlay2 = DistanceToPlayer(player2.transform);
        if (!player2.isPlayerDead && distToPlay2 < closestDistance)
        {
            closestDistance = distToPlay2;
            closestPlayer = player2;
        }

        playerTarget = closestPlayer;

        canThink = true;
    }

    private float DistanceToPlayer(Transform player)
    {
        return Vector2.Distance(player.position, transform.parent.position);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.tag != "Enemy")
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                playerTarget = col.gameObject.GetComponent<Player>();
            }
        }
    }

    private void EnemyMove()
    {
        move.Move((playerTarget.transform.position - transform.parent.position).normalized);
    }
}
