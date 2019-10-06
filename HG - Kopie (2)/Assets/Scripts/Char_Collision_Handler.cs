using UnityEngine;
/** 
 * colliders detect trigger, which are placed at the top and bottom of each ramp
 * depending on which trigger is collided with, the hosatge or hiijacker tilts accordingly
 * lerping is used to have a smooth tilting
 */
public class Char_Collision_Handler : MonoBehaviour {
    public bool moveR = true;
    private float lerpSpeed;
    private float rotationTime;
    private Quaternion startRot;
    private Quaternion endRot;
    void Start() {
        startRot = transform.rotation;
        endRot = transform.rotation;
        lerpSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update() {
        rotationTime += Time.deltaTime * lerpSpeed;
        transform.rotation = Quaternion.Lerp(startRot, endRot, rotationTime);
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        rotationTime = 0.0f;
        TraverseRamp(coll);
    }

    public void TraverseRamp(Collider2D coll) {
        if (coll.tag == "Ramp Bottom") {
            startRot = transform.rotation;
            if (moveR) {
                endRot = startRot * Quaternion.Euler(0.0f, 0.0f, 25.0f);
            } else {
                endRot = startRot * Quaternion.Euler(0.0f, 0.0f, -25.0f);
            }

        }

        if (coll.tag == "Ramp Top") {
            startRot = transform.rotation;
            if (moveR) {
                endRot = startRot * Quaternion.Euler(0.0f, 0.0f, -25.0f);
            } else {
                endRot = startRot * Quaternion.Euler(0.0f, 0.0f, 25.0f);
            }

        }

    }
}