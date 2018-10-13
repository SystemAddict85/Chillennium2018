using UnityEngine;
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

    void Awake()
    {
        move = GetComponent<Movement>();
    }

    public void SetPool(ProjectilePool pool)
    {
        parentPool = pool;
    }

    public void Shoot(Vector2 dir)
    {
        direction = dir;
        move.SetSpeed(speed);
        gameObject.SetActive(true);
    }

    private void Update()
    {
        move.Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        parentPool.Return(this);
    }

}
