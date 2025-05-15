using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyEnemyDestroyController : MonoBehaviour
{
	AudioManager audioManager;

	[SerializeField] private GameObject energyPrefabs;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	private void SpawnEnergy()
	{
		if (energyPrefabs != null)
		{
			GameObject energy = Instantiate(energyPrefabs, transform.position, Quaternion.identity);
			Destroy(energy, 10f);
		}
	}

	public void DestroyEnergyEnemy()
	{
		audioManager.PlaySFX(audioManager.zombiesDeath);
		SpawnEnergy();
		Destroy(gameObject);
	}
}
