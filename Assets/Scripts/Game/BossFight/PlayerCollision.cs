using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	AudioManager audioManager;

	[SerializeField] private BossManager bossManager;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Key"))
		{
			audioManager.PlaySFX(audioManager.energyPickup);
			Debug.Log("Win Game");
			Destroy(collision.gameObject);
		}
		else if (collision.CompareTag("Energy")) 
		{
			audioManager.PlaySFX(audioManager.energyPickup);
			bossManager.AddEnergy();
			Destroy(collision.gameObject);
		}
	}
}
