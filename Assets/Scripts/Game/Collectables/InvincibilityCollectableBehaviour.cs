using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
	[SerializeField]
	private float _invincibilityLength;

	[SerializeField]
	private Color _invincibilityFlashColor;

	[SerializeField]
	private int _numberOfFlashes;

	AudioManager audioManager;
	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public void OnCollected(GameObject player)
	{
		audioManager.PlaySFX(audioManager.invinciblePickup);
		player.GetComponent<InvincibilityController>().StartInvincibility(_invincibilityLength, _invincibilityFlashColor, _numberOfFlashes);
	}
}
