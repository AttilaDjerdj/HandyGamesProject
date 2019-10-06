using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Destroy : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject remainsPrefab;
    public bool wasShot;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnDestroy() {
        //GameObject remains = Instantiate(remainsPrefab, transform.position, Quaternion.identity);
    }

    public void GotHit() {
        GameObject remains = Instantiate(remainsPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}