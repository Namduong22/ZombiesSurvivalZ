using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

	[SerializeField]
	private GameObject _bulletPrefab;

	[SerializeField]
	private float _bulletSpeed;

	[SerializeField]
	private float _timeBetweenShots;

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement>())
		{
			var healthController = collision.gameObject.GetComponent<HealthController>();

			float currentHealth = healthController._currentHealth;

			healthController.TakeDamage(_damageAmount);

			if (healthController._currentHealth < currentHealth)
			{
				var playerShoot = collision.gameObject.GetComponent<PlayerShoot>();
				if (playerShoot != null)
				{
					playerShoot.SetBulletPrefab(_bulletPrefab);
					playerShoot.SetBulletSpeed(_bulletSpeed);
					playerShoot.SetTimeBetweenShots(_timeBetweenShots);
				}
			}
		}
	}
}
