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
            if (playerTarget)
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
        var players = FindObjectsOfType<Player>();

        Player closestPlayer = null;
        float closestDistance = float.MaxValue;
        foreach(var p in players)
        {
            var dist = DistanceToPlayer(p.transform);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestPlayer = p;
            }
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
