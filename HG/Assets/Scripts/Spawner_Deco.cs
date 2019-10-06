using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Deco : MonoBehaviour {
    public List<Sprite> sprites;

    // Use this for initialization
    void Start() {
        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
        rend.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update() {

    }
}