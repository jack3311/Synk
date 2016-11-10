using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Victory! You won in " + Mathf.FloorToInt(TimeTrackerScript.GetTime()).ToString() + " seconds!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
