using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    private Pool pool;

    [SerializeField]
    Projectile proj;

    // Use this for initialization
    void Start () {
        pool = Pool.GetPool(proj);
        Debug.Log("6");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            var projectile = pool.Get(transform.position, Quaternion.identity) as Projectile;

        }

	}
}
