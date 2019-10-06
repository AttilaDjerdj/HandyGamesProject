using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
    // Start is called before the first frame update
    private Text highscore;
    private int defaultHighscore = 60;
    void Start() {
        highscore = GetComponent<Text>();
        highscore.text = PlayerPrefs.GetInt("Highscore", defaultHighscore).ToString();
    }

    // Update is called once per frame
    void Update() {

    }
}