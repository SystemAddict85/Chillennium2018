using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{    
    [SerializeField]
    private ProjectilePool[] pools;

    private Controller controller;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Shoot(int poolNum = 0)
    {
        var proj = pools[poolNum].Get();
        proj.transform.position = transform.position;
        proj.gameObject.SetActive(true);
        
        proj.Shoot(new Vector2(0,-1));
    }


    
}
