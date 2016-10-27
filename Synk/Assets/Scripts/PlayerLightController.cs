using UnityEngine;
using System.Collections;

public class PlayerLightController : MonoBehaviour {

    GameObject playerLight;

	// Use this for initialization
	void Start () {
        playerLight = GameObject.Find("PlayerLight");
	}
	
	// Update is called once per frame
	void Update () {
        playerLight.transform.position = transform.position;
    }
}
