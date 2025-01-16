using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
	[SerializeField]
	private GameObject _bulletPrefab;

	[SerializeField]
	private float _bulletSpeed;

	[SerializeField]
	private float _timeBetweenShots;

	AudioManager audioManager;
	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public void OnCollected(GameObject player)
	{
		audioManager.PlaySFX(audioManager.weaponEquip);
		PlayerShoot playerShoot = player.GetComponent<PlayerShoot>();
		if (playerShoot != null)
		{
			playerShoot.SetBulletPrefab(_bulletPrefab);
			playerShoot.SetBulletSpeed(_bulletSpeed);
			playerShoot.SetTimeBetweenShots(_timeBetweenShots);
		}
	}
}
