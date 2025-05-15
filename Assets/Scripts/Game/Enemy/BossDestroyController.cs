using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroyController : MonoBehaviour
{
	AudioManager audioManager;

	[SerializeField] private GameObject keyPrefabs;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	private void SpawnKey()
	{
		if (keyPrefabs != null)
		{
			Instantiate(keyPrefabs, transform.position, Quaternion.identity);
		}
	}

	public void DestroyEnemy()
	{
		audioManager.PlaySFX(audioManager.zombiesDeath);
		SpawnKey();
		Destroy(gameObject);
	}
}
