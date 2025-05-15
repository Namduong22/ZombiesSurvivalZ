using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
	[SerializeField] private float enemyBulletDamage;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<PlayerMovement>())
		{
			HealthController healthController = collision.GetComponent<HealthController>();
			healthController.TakeDamage(enemyBulletDamage);
			Destroy(gameObject);
		}

		if (collision.GetComponent<Wall>())
		{
			Destroy(gameObject);
		}
	}
}
