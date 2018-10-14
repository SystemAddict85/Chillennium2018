using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [HideInInspector]
    public bool isDashing = false;

    [SerializeField]
    private float dashSpeed = 8f;
    private PlayerController control;
    private Vector3 dir;
    private Collider2D levelBounds;

    [SerializeField]
    private float dashTime;
    private float currentTime;

    private void Awake()
    {
        control = GetComponent<PlayerController>();
    }

    public void SetDashDirection(Vector3 dir)
    {
        this.dir = dir.normalized;
        isDashing = true;
        GetComponent<Movement>().ToggleMovement(false);
    }

    private void Start()
    {
        levelBounds = LevelManager.Instance.GetComponent<Collider2D>();
    }

    private void Update()
    {
        CheckIfDashing();
    }

    private void CheckIfDashing()
    {
        if (isDashing)
        {
            Dash();
        }
    }

    private bool CheckBounds(Vector3 pos)
    {
        Vector2 boundary = levelBounds.bounds.extents;
        Debug.Log(pos);
        Debug.Log(boundary);
        return Mathf.Abs(pos.x) < Mathf.Abs(boundary.x) && Mathf.Abs(pos.y) < Mathf.Abs(boundary.y);      
    }

    public void Dash()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= dashTime)
        {
            FinishDash();
        }
        else
        {
            if (CheckBounds(transform.position + dir * dashSpeed * Time.deltaTime))
                transform.position += dir * dashSpeed * Time.deltaTime;
            else
            {
                FinishDash();
            }
        }

    }
    private void FinishDash()
    {
        isDashing = false;
        currentTime = 0;
        control.FinishDashing();
        GetComponent<Movement>().ToggleMovement(true);
    }
    

}
