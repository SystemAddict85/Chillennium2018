using UnityEngine;

public class Movement : MonoBehaviour
{
    private Controller control;
    [SerializeField]
    private float moveSpeed;

    private void Awake()
    {
        control = GetComponent<Controller>();
    }

    private void Update()
    {
        CheckForMovement();
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
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
