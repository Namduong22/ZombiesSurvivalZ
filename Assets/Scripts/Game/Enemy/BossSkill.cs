using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefabs;
	[SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float circleBulletSpeed;
    [SerializeField] private float hpValue;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCoolDown;
    private float nextSkillTime = 0f;

	private PlayerMovement player;

	AudioManager audioManager;
	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
		player = FindObjectOfType<PlayerMovement>();
	}

	private void Update()
	{
        if (Time.time >= nextSkillTime) 
        {
            UseSkill();
        }
	}

    private void ShotBullet()
    {
        if (player != null) 
        {
			audioManager.PlaySFX(audioManager.laserShot);
			Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDiretion(directionToPlayer * bulletSpeed);
        }
    }

    private void ShotCircleBullet()
    {
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
		audioManager.PlaySFX(audioManager.laserShot);
		for (int i = 0; i < bulletCount; i++)
        {
			float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDiretion(bulletDirection * circleBulletSpeed);
        }
    }

    private void Heal() 
    {
        audioManager.PlaySFX(audioManager.healthPickup);
		HealthController healthController = GetComponent<HealthController>();
		healthController.AddHealth(hpValue);
	}

	private void SpawnEnemy()
	{
		Instantiate(miniEnemy, transform.position, Quaternion.identity);
	}

    private void Teleport()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

	private void RandomSkill()
	{
		int randomSkill = Random.Range(0, 7);
        switch (randomSkill)
        {
            case 0:
                ShotBullet();
                break;
			case 1:
				ShotBullet();
				break;
			case 2:
                ShotCircleBullet();
                break;
            case 3:
                ShotCircleBullet();
                break;
            case 4:
                Heal();
                break;
            case 5:
                SpawnEnemy();
                break;
            case 6:
                Teleport();
                break;
        }
	}

    private void UseSkill()
    {
        nextSkillTime = Time.time + skillCoolDown;
        RandomSkill();
    }
}
