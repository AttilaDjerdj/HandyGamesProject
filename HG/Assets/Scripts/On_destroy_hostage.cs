using UnityEngine;

/** 
 * is solely used for hostages to instantiate a dead hostage or happy hostage
 * note: not finished, only happy hostage / remeining hostage
 */
public class On_destroy_hostage : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    private GameObject saved;
    [SerializeField]
    private GameObject dead;
    [SerializeField]
    private GameObject hostagesDisplay;
    void Start() {
        hostagesDisplay = GameObject.FindGameObjectWithTag("Hostages Display");
    }

    public void CallDestroy(bool wasSaved) {
        if (wasSaved) {
            GameObject remains = Instantiate(saved, transform.position, Quaternion.identity);
            hostagesDisplay.GetComponent<Hostages_Display>().addHostage(remains);
        } else {
            GameObject remains = Instantiate(dead, transform.position, Quaternion.identity);
            hostagesDisplay.GetComponent<Hostages_Display>().addHostage(remains);
        }
        Destroy(this.transform.parent.parent.gameObject);
    }
}