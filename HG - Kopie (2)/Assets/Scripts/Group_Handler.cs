using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Group_Handler : MonoBehaviour {

    [SerializeField]
    private GameObject hostage;
    [SerializeField]
    private List<GameObject> hijackers;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!hijackers.Any()) {
            hostage.GetComponent<On_destroy_hostage>().CallDestroy(true);
            //Destroy(hostage);
        }
    }

    public void SetHostage(GameObject hostage) {
        this.hostage = hostage;
    }

    public void AddHijacker(GameObject hj) {
        hijackers.Add(hj);
    }

    public void RemoveHijacker(GameObject hj) {
        hijackers.Remove(hj);
    }
}