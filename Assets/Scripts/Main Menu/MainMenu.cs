﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneController _sceneController;


    public void Play()
    {
        _sceneController.LoadScene("Level Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
