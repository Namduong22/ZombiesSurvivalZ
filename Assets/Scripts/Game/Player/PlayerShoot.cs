using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;

    AudioManager audioManager;

	private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if(timeSinceLastFire >= _timeBetweenShots)
            {
				FireBullet();

				_lastFireTime = Time.time;
                _fireSingle = false;
			}
        }
    }

	public void FireBullet()
	{
        audioManager.PlaySFX(audioManager.gunshot);
		GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
	}

	private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed )
        {
            _fireSingle = true;
        }
    }
	public void SetBulletPrefab(GameObject newBulletPrefab)
	{
		_bulletPrefab = newBulletPrefab;
	}

	public void SetBulletSpeed(float newBulletSpeed)
	{
		_bulletSpeed = newBulletSpeed;
	}

	public void SetTimeBetweenShots(float newTimeBetweenShots)
	{
		_timeBetweenShots = newTimeBetweenShots;
	}
}
