using UnityEngine;
using System.Collections;

public class PlayerLightController : MonoBehaviour {

    GameObject playerLight;

	// Use this for initialization
	void Start () {
        playerLight = GameObject.Find("PlayerLight");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 delta = mousePos - new Vector2(transform.position.x, transform.position.y);
        delta.Normalize();

        playerLight.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        playerLight.transform.LookAt(transform.position + new Vector3(delta.x, delta.y, 0) * 5f);
    }
}
