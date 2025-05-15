using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("---------- Audio Source ----------")]
	[SerializeField] AudioSource musicSource;
	[SerializeField] AudioSource SFXSource;

	[Header("---------- Audio Clip ----------")]
	public AudioClip bgm;
	public AudioClip ingameBGM;
	public AudioClip gunshot;
	public AudioClip laserShot;
	public AudioClip playerHurt;
	public AudioClip playerDeath;
	public AudioClip zombiesHurt;
	public AudioClip zombiesDeath;
	public AudioClip weaponEquip;
	public AudioClip healthPickup;
	public AudioClip invinciblePickup;
	public AudioClip energyPickup;


	private void Start()
	{
		musicSource.clip = ingameBGM;
		musicSource.Play();
	}

	public void PlaySFX(AudioClip clip)
	{
		SFXSource.PlayOneShot(clip);
	}
}

	