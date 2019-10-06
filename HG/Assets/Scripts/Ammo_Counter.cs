using UnityEngine;
using UnityEngine.UI;

public class Ammo_Counter : MonoBehaviour {

    // Start is called before the first frame update
    [SerializeField]
    private GameObject shootingHandlerObject;
    private Shooting_Handler shootingHandler;
    private int ammoCount;
    private Text ammoCountText;
    void Start() {
        shootingHandler = shootingHandlerObject.GetComponent<Shooting_Handler>();
        ammoCountText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        ammoCount = shootingHandler.getAmmo();
        ammoCountText.text = "";
        ammoCountText.text = "Ammo: " + ammoCount.ToString();

    }
}