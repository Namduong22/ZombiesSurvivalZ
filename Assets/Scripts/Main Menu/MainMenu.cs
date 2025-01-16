using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCanvas;
    [SerializeField]
    private GameObject secondCanvas;

    private void Start()
    {
        mainCanvas.SetActive(true);
        secondCanvas.SetActive(false);
    }

    public void Play()
    {
        mainCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void BackToMainMenu()
    {
        mainCanvas.SetActive(true);
        secondCanvas.SetActive(false);
    }
}
