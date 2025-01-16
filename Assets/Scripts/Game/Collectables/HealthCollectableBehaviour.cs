using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _healthAmount;

	AudioManager audioManager;
	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public void OnCollected(GameObject player)
    {
		audioManager.PlaySFX(audioManager.healthPickup);
		player.GetComponent<HealthController>().AddHealth(_healthAmount);
    }
}
