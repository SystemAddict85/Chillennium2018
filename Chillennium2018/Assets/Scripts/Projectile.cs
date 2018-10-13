﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeDuration;
    private Vector2 direction;
    
    private Movement move;
    private ProjectilePool parentPool;
    private bool timerStarted = false;

    private float currentTime = 0f;

    void Awake()
    {
        move = GetComponent<Movement>();
        lifeDuration = 5f;
    }

    private void OnEnable()
    {
        currentTime = 0f;
    }

    public void SetPool(ProjectilePool pool)
    {
        parentPool = pool;
    }

    public void Shoot(Vector2 dir)
    {
        timerStarted = false;
        currentTime = 0f;
        direction = dir;
        move.SetSpeed(speed);
        gameObject.SetActive(true);
        timerStarted = true;
    }

    private void Update()
    {
        if (timerStarted)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= lifeDuration)
            {
                timerStarted = false;
                currentTime = 0f;
                gameObject.SetActive(false);
                parentPool.Return(this);

            }
        }

        move.Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timerStarted = false;
        currentTime = 0f;
        parentPool.Return(this);
    }

}
