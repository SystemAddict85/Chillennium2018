using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMine : MonoBehaviour, IPoolable {
    public event Action OnDestroyEvent;

    public Rigidbody2D projectile;
    public Transform projSpawnPoint;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
