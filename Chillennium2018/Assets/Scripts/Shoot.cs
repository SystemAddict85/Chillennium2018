using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    GameObject bulletPrefab;
    Transform bulletSpawn;

    void Update()
    {

        var x = Input.GetAxis("Horizontal1") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical1") * Time.deltaTime * 3.0f;
        bulletSpawn = transform;

        if (Input.GetAxisRaw("Horizontal1") != 0 || Input.GetAxisRaw("Vertical1") != 0)
        {
            Fire();
        }
    }

    // Update is called once per frame
    void Fire () {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        
        Destroy(bullet, 2.0f);
    }
}
