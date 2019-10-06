using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingame_Menu : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject pauseMenu;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (!pauseMenu.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Pause();
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Resume();
            }
        }

    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Exit() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}