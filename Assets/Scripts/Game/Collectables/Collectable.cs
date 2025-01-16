using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	[SerializeField]
	private float _expiryTime;

	private SpriteFlash _spriteFlash;
	private ICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
		_spriteFlash = GetComponent<SpriteFlash>();
		_collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }

	private void OnEnable()
	{
		Invoke(nameof(StartExpiry), _expiryTime);
	}

	private void StartExpiry()
	{
		if (isActiveAndEnabled)
		{
			StartCoroutine(ExpiryCoroutine());
		}
	}

	private IEnumerator ExpiryCoroutine()
	{
		yield return _spriteFlash.FlashCoroutine(3, new Color(1, 1, 1, 0.5f), 7);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if (player != null)
        {
            _collectableBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }

}
