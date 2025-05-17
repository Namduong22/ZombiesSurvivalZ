using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneController _sceneController;

	[SerializeField]
	private GameObject mainMenu;

	[SerializeField]
	private GameObject optionMenu;

	private void Start()
	{
		mainMenu.SetActive(true);
		optionMenu.SetActive(false);
	}

	public void Play()
    {
        _sceneController.LoadScene("Level Menu");
    }

	public void Options()
	{
		mainMenu.SetActive(false);
		optionMenu.SetActive(true);
	}

    public void Exit()
    {
        Application.Quit();
    }

	public void BackToMainMenu()
	{
		mainMenu.SetActive(true);
		optionMenu.SetActive(false);
	}

}
