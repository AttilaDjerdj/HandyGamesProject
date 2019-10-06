using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Handler : MonoBehaviour {
    public GameObject loose;
    [SerializeField]
    private GameObject shot;
    private LayerMask layerMask = ((1 << 8) | (1 << 17));
    private int ammo = 20;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (ammo < 0) {
            /* activade loose panel*/
            Loose();
        }

        if (Input.GetMouseButtonDown(0) && (Time.timeScale == 1)) {
            ammo -= 1;
            if (ammo > 0) {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100.0f, layerMask);
                Instantiate(shot, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.0f, 0.0f, 5.0f), Quaternion.identity);
                if (hit) {
                    if (hit.transform.gameObject.tag == "Hijacker") {
                        hit.transform.parent.GetComponent<Group_Handler>().RemoveHijacker(hit.transform.gameObject);
                        hit.transform.GetComponent<On_Destroy>().GotHit();
                    }
                }
            }
        }
    }

    public int getAmmo() {
        return ammo;
    }

    void Loose() {
        Time.timeScale = 0;
        loose.SetActive(true);
    }
}