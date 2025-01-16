using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
	[SerializeField]
	private float _invincibilityDuration;

    [SerializeField]
    private Color _flashColor;

    [SerializeField]
    private int _numberOfFlashes;

    private InvincibilityController _invincibilityController;

	AudioManager audioManager;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
		_invincibilityController = GetComponent<InvincibilityController>();
	}

	public void StartInvincibility()
    {
		audioManager.PlaySFX(audioManager.playerHurt);
		_invincibilityController.StartInvincibility(_invincibilityDuration, _flashColor, _numberOfFlashes);
    }
}
