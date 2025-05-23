using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void ContinueGame()
    {
        gameManager.ResumeGame();
    }

    public void LoadMainMenu()
    {
		SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
	}
}
