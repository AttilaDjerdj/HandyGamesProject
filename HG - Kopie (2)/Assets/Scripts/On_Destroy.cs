using UnityEngine;

/** is solely used for hijackers to instansiate punished ladybugs */
public class On_Destroy : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject remainsPrefab;
    public bool wasShot;

    public void GotHit() {
        GameObject remains = Instantiate(remainsPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}