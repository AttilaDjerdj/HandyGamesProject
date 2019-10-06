using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment_Generator : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> parts;
    [SerializeField]
    private List<int> segment;
    private float offsetStepX = 1.0f;
    private float offsetStepY = 0.4f;
    private float offsetStepZ = -1.0f;
    private float offsetX = 0.0f;
    private float offsetY = 0.4f;
    private float offsetZ = 1.0f;
    private int nextRow = 4;
    private int nextRowCounter = 0;
    private int listIndex = 0;
    enum nameToListIndex {
        c,
        d,
        D,
        e,
        g,
        G,
        p,
        E,
        W,
        s,
        w,
        a
    }

    void Start() {
        foreach (char ch in transform.name) {
            listIndex = (int) nameToListIndex.s;
            Debug.Log(ch);
            if (nextRowCounter == 4) {
                offsetX = 0.0f;
                offsetY = offsetY + offsetStepY;
                offsetZ = offsetZ + offsetStepZ;
                nextRowCounter = 0;
            }
            GameObject part = Instantiate(parts[ch], transform.position + new Vector3(offsetX, offsetY, offsetZ), Quaternion.identity);
            part.transform.SetParent(transform);
            offsetX = offsetX + offsetStepX;

            nextRowCounter++;
        }
        // foreach (int partIndex in segment) {
        //     if (nextRowCounter == 4) {
        //         offsetX = 0.0f;
        //         offsetY = offsetY + offsetStepY;
        //         offsetZ = offsetZ + offsetStepZ;
        //         nextRowCounter = 0;
        //     }
        //     GameObject part = Instantiate(parts[partIndex], transform.position + new Vector3(offsetX, offsetY, offsetZ), Quaternion.identity);
        //     part.transform.SetParent(transform);
        //     offsetX = offsetX + offsetStepX;

        //     nextRowCounter++;
        //     // offsetY = offsetY + offsetStepY;
        //     // offsetZ = offsetZ + offsetStepZ;
        // }

    }

    // Update is called once per frame
    void Update() {

    }

    public void AddPart(GameObject hj) {
        parts.Add(hj);
    }

    public void RemovePart(GameObject hj) {
        parts.Remove(hj);
    }
}