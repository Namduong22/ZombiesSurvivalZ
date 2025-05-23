using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
	[SerializeField]
	private SceneController _sceneController;

	public void LoadLevel1()
	{
		_sceneController.LoadScene("Level 1");
	}

	public void LoadLevel2()
	{
		_sceneController.LoadScene("Level 2");
	}

	public void LoadLevel3()
	{
		_sceneController.LoadScene("Level 3");
	}

	public void LoadBossLevel()
	{
		_sceneController.LoadScene("Boss Level");
	}

	public void ReturnMainMenu()
	{
		_sceneController.LoadScene("Main Menu");
	}
}
