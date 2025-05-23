using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject _itemPrefab;

	[SerializeField]
	private float _minimumSpawnTime;

	[SerializeField]
	private float _maximumSpawnTime;

	private float _timeUntilSpawn;

	void Awake()
	{
		SetTimeUntilSpawn();
	}

	// Update is called once per frame
	void Update()
	{
		_timeUntilSpawn -= Time.deltaTime;

		if (_timeUntilSpawn <= 0)
		{
			Instantiate(_itemPrefab, transform.position, Quaternion.identity);
			SetTimeUntilSpawn();
		}
	}

	private void SetTimeUntilSpawn()
	{
		_timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
	}
}
