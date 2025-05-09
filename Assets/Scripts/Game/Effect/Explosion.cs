using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		HealthController healthController = collision.GetComponent<HealthController>();
		if (healthController == null) return;

		if (collision.GetComponent<EnemyMovement>() || collision.GetComponent<PlayerMovement>())
		{
			healthController.TakeDamage(damage);
		}
	}

	private void DestroyExplosion()
	{
		Destroy(gameObject);
	}
}
