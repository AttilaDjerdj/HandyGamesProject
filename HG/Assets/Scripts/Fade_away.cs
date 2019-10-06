using UnityEngine;
/** 
 * 
 */
public class Fade_away : MonoBehaviour {
    // Start is called before the first frame update
    private SpriteRenderer renderer;
    private float startVal = 1.0f;
    private float endVal = 0.0f;
    private float passedTime = 0f;
    void Start() {
        passedTime = 0.0f;
        renderer = GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update() {
        passedTime += Time.deltaTime;
        Color newColor = new Color(1, 1, 1, Mathf.Lerp(startVal, endVal, passedTime));
        renderer.color = newColor;
    }
}