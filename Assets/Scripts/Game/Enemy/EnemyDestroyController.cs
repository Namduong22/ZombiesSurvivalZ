using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
	AudioManager audioManager;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public void DestroyEnemy(float delay)
    {
		audioManager.PlaySFX(audioManager.zombiesDeath);
		Destroy(gameObject, delay);
    }
}
