using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField]
    private Projectile prefab;
    [SerializeField]
    private int spawnNum;

    private Queue<Projectile> readyQueue = new Queue<Projectile>();

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        // move behind camera
        transform.position += new Vector3(0, 0, -100);
        for(int i = 0; i < spawnNum; ++i)
        {
            var proj = Instantiate(prefab, transform);
            proj.SetPool(this);            
            proj.gameObject.SetActive(false);
            readyQueue.Enqueue(proj);
        }
    }

    public Projectile Get()
    {
        return readyQueue.Dequeue();
    }

    public void Return(Projectile proj) {
        readyQueue.Enqueue(proj);
    }
}
