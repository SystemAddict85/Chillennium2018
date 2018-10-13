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
        if (Input.GetAxisRaw("Horizontal1") != 0 || Input.GetAxisRaw("Vertical1") != 0)
        {
           // Debug.Log("hmm");
            Shoot();
        }
    }

    public void Shoot(int poolNum = 0)
    {
        var proj = pools[poolNum].Get();
        proj.transform.position = transform.position;
        proj.gameObject.SetActive(true);
       // Debug.Log("trying");
        proj.Shoot(new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1")));
    }


    
}
