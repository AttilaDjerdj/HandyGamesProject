using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment_Properties : MonoBehaviour {
    [SerializeField]
    private string segType;
    private void Awake() {
        generateType();
    }

    public string getSegType() {
        generateType();
        return segType;
    }

    private void generateType() {
        segType = name.Substring(2, 2);
    }
}