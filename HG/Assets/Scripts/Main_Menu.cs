﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour {
    // Start is called before the first frame update

    public void StartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
}