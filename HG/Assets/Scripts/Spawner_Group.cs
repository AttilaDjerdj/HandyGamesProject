using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Group : MonoBehaviour {
    [SerializeField]
    private List<GameObject> characters;
    [SerializeField]
    private List<GameObject> spawnpoints;
    public GameObject ladybug;
    public GameObject group;
    public GameObject groupMoverBox;

    public int maxLadybugs = 2;

    int ladybugsL;
    int ladybugsR;
    int spawnpointsIndex;
    private float counter = 0.0f;

    // Start is called before the first frame update
    void Start() {
        foreach (GameObject spawnpoint in spawnpoints) {
            int secondsToWait = Random.Range(3, 10);
            StartCoroutine(WaitToSpawnNextGroup(secondsToWait, spawnpoint));
        }
    }

    // Update is called once per frame
    void Update() {

    }
    /* set layer of parent object and every child object of that parent recursively */
    public void SetLayer(Transform parent, int layer) {
        parent.gameObject.layer = layer;
        foreach (Transform child in parent) {
            if (child.gameObject.layer != 8) {
                SetLayer(child, layer);
            }

        }
    }

    IEnumerator WaitToSpawnNextGroup(float secondsToWait, GameObject spawnpoint) {
        yield return new WaitForSecondsRealtime(secondsToWait);
        int charactersIndex = Random.Range(0, characters.Count);
        GameObject groupMover = Instantiate(groupMoverBox, spawnpoint.transform.position, Quaternion.identity);
        GameObject groupObject = GameObject.Instantiate(group, spawnpoint.transform.position, Quaternion.identity);
        groupObject.transform.SetParent(groupMover.transform);

        GameObject character = GameObject.Instantiate(characters[charactersIndex], spawnpoint.transform.position, Quaternion.identity);
        character.transform.SetParent(groupObject.transform);

        groupObject.GetComponent<Group_Handler>().SetHostage(character);

        ladybugsL = Random.Range(0, maxLadybugs);
        ladybugsR = Random.Range(0, maxLadybugs);

        for (int i = 1; i <= ladybugsL + 1; ++i) {
            GameObject lb = GameObject.Instantiate(ladybug, spawnpoint.transform.position + new Vector3(-i, 0.0f, 0.0f), Quaternion.identity);
            lb.transform.SetParent(groupObject.transform);
            groupObject.GetComponent<Group_Handler>().AddHijacker(lb);
        }

        for (int i = 1; i <= ladybugsR + 1; ++i) {
            GameObject lb = GameObject.Instantiate(ladybug, spawnpoint.transform.position + new Vector3(i, 0.0f, 0.0f), Quaternion.identity);
            lb.transform.SetParent(groupObject.transform);
            groupObject.GetComponent<Group_Handler>().AddHijacker(lb);
        }

        SetLayer(groupObject.transform, spawnpoint.layer);

        characters.RemoveAt(charactersIndex);

    }
}