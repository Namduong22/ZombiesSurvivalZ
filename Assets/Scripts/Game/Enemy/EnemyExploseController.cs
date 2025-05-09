using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploseController : MonoBehaviour
{
	AudioManager audioManager;

	[SerializeField] private GameObject explosionPrefabs;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	private void CreateExplosion()
	{
		if (explosionPrefabs != null)
		{
			Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
		}
	}

	public void ExploseEnemy()
	{
		audioManager.PlaySFX(audioManager.zombiesDeath);
		CreateExplosion();
		Destroy(gameObject);
	}
}
