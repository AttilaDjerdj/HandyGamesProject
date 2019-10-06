using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * each level is randomly generated and consists of several paths (5 in this case)
 * each path is randomly generated using predefined segements
 * the segments hold inidviduell properties and the paths are build according to these properties
 * each level is furthermore split into two areas, pavement and green
 * whether the top half, respectively the bottom half, is green or pavement is randomly decided 
 */
public class Level_Generator : MonoBehaviour {
    /** whether the top half of the level is green or pavement, the bottom half is the opposit */
    private int isBottomGreen;
    [SerializeField]
    private float segmentWidth = 4;
    [SerializeField]
    private float segmentHeight = 0.8f;
    [SerializeField]
    private int levelWidth = 2;
    /** how the level is split */
    [SerializeField]
    private int nmbOfBottomPaths = 3;
    [SerializeField]
    private List<GameObject> greenSegments;
    [SerializeField]
    private List<GameObject> pavementSegments;
    [SerializeField]
    private List<GameObject> spawnpoints;

    void Awake() {
        GenerateLevel();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void GenerateLevel() {
        
         /** randomly decide, whether top is green or not */
        isBottomGreen = Random.Range(0, 2);
        Vector3 segmentPos = transform.position;

        /* generate a path for each spawnpoint */
        for (int i = 0; i < spawnpoints.Count; ++i) {

            /**
             * bottom half is generated first, top half is generated afterwards
             * translation in z direction ist important to avoid clipping
             * */
            segmentPos.z = i;
            if (i < 3) {
                if (isBottomGreen == 1) {
                    GeneratePath(greenSegments, segmentPos, spawnpoints[i].layer, spawnpoints[i]);
                } else {
                    GeneratePath(pavementSegments, segmentPos, spawnpoints[i].layer, spawnpoints[i]);
                }
            } else {
                if (isBottomGreen == 1) {
                    GeneratePath(pavementSegments, segmentPos, spawnpoints[i].layer, spawnpoints[i]);
                } else {
                    GeneratePath(greenSegments, segmentPos, spawnpoints[i].layer, spawnpoints[i]);
                }
            }
            segmentPos.y += segmentHeight;
        }
    }

    public void GeneratePath(List<GameObject> segments, Vector3 segmentPos, int layerNmb, GameObject sp) {
        string segType = null;
        string segTypePrev = null;
        for (int j = 1; j <= levelWidth; ++j) {
            GameObject segment = segments[Random.Range(0, segments.Count)];
            Segment_Properties properties = segment.GetComponent<Segment_Properties>();
            segType = properties.getSegType();
            if (j != 1) {
                while (!(segType[0].Equals(segTypePrev[1]))) {
                    segment = segments[Random.Range(0, segments.Count)];
                    properties = segment.GetComponent<Segment_Properties>();
                    segType = properties.getSegType();
                }
            } else {
                if (segType[0] != '1') {
                    sp.transform.position += new Vector3(0.0f, (segType[0] - 48) * (segmentHeight / 2) - (segmentHeight / 2), 0.0f);
                }
            }
            segTypePrev = properties.getSegType();
            GameObject pathSegment = Instantiate(segment, segmentPos, Quaternion.identity);
            segmentPos.x += segmentWidth;
            pathSegment.transform.SetParent(transform);
            SetLayer(pathSegment.transform, layerNmb);
        }
    }

    /** set layer of parent object and every child object of that parent recursively
     * note: layer 17 / decoration is ignored while setting layers
     */
    public void SetLayer(Transform parent, int layer) {
        parent.gameObject.layer = layer;
        foreach (Transform child in parent) {
            if (child.gameObject.layer != 17) {
                SetLayer(child, layer);
            }

        }
    }
}
