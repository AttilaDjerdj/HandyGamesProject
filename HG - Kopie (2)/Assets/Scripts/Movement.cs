using System.Collections.Generic;
using UnityEngine;

/**
 * each individual is moved with the physics engine of unity
 * speed is fixed at 3.0f
 * toDo: adjustable speed
 */
public class Movement : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private List<Movement> movements;
    private List<Char_Collision_Handler> charCollisionHandlers;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb.MovePosition(transform.position + (transform.right * Time.fixedDeltaTime * speed));
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "turnR") {

            setSpeed(-3.0f);
            foreach (Transform child in transform.GetChild(0)) {
                child.GetComponent<Movement>().setSpeed(-3.0f);
                child.GetComponent<SpriteRenderer>().flipX = true;
                child.GetComponent<Char_Collision_Handler>().moveR = false;
            }
        }

        if (coll.tag == "turnL") {
            setSpeed(3.0f);
            foreach (Transform child in transform.GetChild(0)) {
                child.GetComponent<Movement>().setSpeed(3.0f);
                child.GetComponent<SpriteRenderer>().flipX = false;
                child.GetComponent<Char_Collision_Handler>().moveR = true;
            }
        }
    }
}