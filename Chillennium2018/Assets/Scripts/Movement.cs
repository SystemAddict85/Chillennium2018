using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool hasController = true;
    private Controller control;

    public bool canMove = true;

    private void Awake()
    {
        control = GetComponent<Controller>();
    }

    private void Update()
    {
        if (hasController)
        {
            CheckForMovement();
        }
    }

    private void CheckForMovement()
    {
        float hor = control.Horizontal, vert = control.Vertical;

        if (Mathf.Abs(hor) > 0 || Mathf.Abs(vert) > 0)
        {
            Move(new Vector2(hor, vert));
        }
    }

    public void Move(Vector3 dir)
    {
        if (canMove)
        {
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }    

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void ToggleMovement(bool enabled)
    {
        canMove = enabled;
    }
}
