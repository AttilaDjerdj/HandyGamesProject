using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostages_Display : MonoBehaviour {
    [SerializeField]
    private GameObject blankSprite;
    [SerializeField]
    private GameObject win;
    private Vector3 displayPos;
    private GameObject timeCounter;

    private List<GameObject> hostages;
    // Start is called before the first frame update
    void Start() {
        //displayPos = new Vector3(Camera.main.pixelWidth - (Camera.main.pixelWidth / 10), Camera.main.pixelHeight - (Camera.main.pixelHeight / 10), 0.0f);
        displayPos = new Vector3(7.5f, 5.6f, 0.0f);
        hostages = new List<GameObject>();
        timeCounter = GameObject.FindGameObjectWithTag("Time");
    }

    // Update is called once per frame
    void Update() {
        if (hostages.Count >= 5) {
            Win();
        }
    }

    public void addHostage(GameObject hostage) {
        hostages.Add(hostage);
        updateDisplayHostages(hostage);
    }

    public void updateDisplayHostages(GameObject hostage) {
        GameObject displayedhostage = Instantiate(hostage, displayPos, Quaternion.identity);
        displayedhostage.transform.localScale -= new Vector3(0.5f, 0.5f, 0.0f);
        displayedhostage.GetComponent<SpriteRenderer>().sprite = hostage.GetComponent<SpriteRenderer>().sprite;
        displayPos += new Vector3(-0.4f, 0.0f, 0.0f);
        Debug.Log(hostage.name);
    }

    public void Win() {
        timeCounter.GetComponent<Time_Counter>().saveTime();
        Time.timeScale = 0;
        win.SetActive(true);
    }
}