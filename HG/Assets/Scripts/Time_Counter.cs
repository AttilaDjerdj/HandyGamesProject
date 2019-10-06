using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Counter : MonoBehaviour {
    // Start is called before the first frame update
    private float time;
    private Text inputText;
    private GameObject loose;
    void Start() {
        time = 60;
        inputText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (time >= 0.0f) {
            time -= Time.deltaTime;
        } else {
            Loose();
        }
        inputText.text = getTime().ToString();
    }

    public int getTime() {
        return (int) time;
    }

    public void saveTime() {
        PlayerPrefs.SetInt("Highscore", getTime());
        PlayerPrefs.Save();
    }

    void Loose() {
        Time.timeScale = 0;
        loose.SetActive(true);
    }
}