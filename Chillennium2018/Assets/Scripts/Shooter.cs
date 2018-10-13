using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{    
    [SerializeField]
    private ProjectilePool pool;

    private Controller controller;

    private void Awkae()
    {
        controller = GetComponent<Controller>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Shoot()
    {
        pool.Get().Shoot(transform.forward);
    }


    
}
