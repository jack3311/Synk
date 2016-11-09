using UnityEngine;
using System.Collections;

public class ParallaxEffect : MonoBehaviour {

    [SerializeField]
    private float distance;

    private Vector2 cameraStartPosition;

    // Use this for initialization
    void Start () {
        cameraStartPosition = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float yOffset = (1f - (1f / distance)) * (Camera.main.transform.position.y - cameraStartPosition.y);
        transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
	}


}
