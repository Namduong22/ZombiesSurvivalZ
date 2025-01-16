using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Camera _camera;

	AudioManager audioManager;

	private void Awake()
	{
		_camera = Camera.main;
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	private void Update()
	{
		DestroyWhenOffScreen();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<EnemyMovement>())
		{
			audioManager.PlaySFX(audioManager.zombiesHurt);
			HealthController healthController = collision.GetComponent<HealthController>();
			healthController.TakeDamage(10);
			Destroy(gameObject);
		}
	}

	private void DestroyWhenOffScreen()
	{
		Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

		if (screenPosition.x < 0 ||
			screenPosition.x > _camera.pixelWidth ||
			screenPosition.y < 0 ||
			screenPosition.y > _camera.pixelHeight)
		{
			Destroy(gameObject);
		}
	}	
}
