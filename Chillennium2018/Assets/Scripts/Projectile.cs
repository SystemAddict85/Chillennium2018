using System;
using UnityEngine;

public class Projectile : MonoBehaviour, IPoolable
{
	[SerializeField]
	protected float speed = 5f;

	//[SerializeField]
	//[Tooltip("How much damage it will do to a player on hit.")]
	//protected int damage = 10;

	[SerializeField]
	private float lifetime = 10f;

	private bool collided;
	private float timer;

	public event Action OnDestroyEvent = delegate { };

	public Vector3 Direction { get; private set; }

	//private void OnDisable() { OnDestroyEvent(); }

	private void OnEnable()
	{
		Reset();
	}

	protected virtual void Reset()
	{
		timer = 0f;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		collided = false;
	}

	public void SetDirection(Vector3 direction)
	{
		Direction = direction;
	}


	private void Update()
	{
		if (ShouldMove())
			Move();

		timer += Time.deltaTime;
		if (timer >= lifetime)
			SelfDestruct();
	}

	private bool ShouldMove()
	{
		return true;
	}

	protected virtual void Move()
	{
		var movement = Direction * speed * Time.deltaTime;

		GetComponent<Rigidbody>().MovePosition(transform.position + movement);
	}

	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collided)
	//		return;

	//	if (collision.collider.GetComponent<Health>() != null)
	//	{
	//		var health = collision.collider.GetComponent<Health>();
	//		health.TakeDamage(damage);

	//		collided = true;

	//		SelfDestruct();
	//	}
	//}
    
	protected void SelfDestruct()
	{
		// particles, etc, remove from pool
		gameObject.SetActive(false);
	}
}