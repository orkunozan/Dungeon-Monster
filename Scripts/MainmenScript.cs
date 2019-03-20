﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenScript : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Info()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
