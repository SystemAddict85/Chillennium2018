using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{

    private bool isDashing = false;

    [SerializeField]
    private float dashSpeed = 8f;
    private Controller control;
    private Vector3 dir;

    [SerializeField]
    private float dashTime;

    private void Awake()
    {
        control = GetComponent<Controller>();
    }

    public void SetDashDirection(Vector3 dir)
    {
        this.dir = dir;
        isDashing = true;
    }

    private void Update()
    {
        CheckIfDashing();
    }

    private void CheckIfDashing()
    {
        if (isDashing)
            Dash();
    }

    private bool CheckBounds()
    {
        Vector2 spawnBounds = boxCollider2D.bounds.extents;
        spawnBounds.x = Random.Range(-spawnBounds.x, spawnBounds.x);
        spawnBounds.y = Random.Range(-spawnBounds.y, spawnBounds.y);
        return spawnBounds;
    }

    public void Dash()
    {
        transform.position += dir * dashSpeed * Time.deltaTime;
    }

}
