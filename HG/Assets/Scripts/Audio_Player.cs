using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Player : MonoBehaviour {
    // Start is called before the first frame update

    [SerializeField]
    private AudioClip clip;
    void Start() {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update() {

    }
}