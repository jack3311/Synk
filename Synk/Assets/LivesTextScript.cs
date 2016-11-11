using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Text>().text = "Lives : " + PlayerLifeController.GetLives().ToString();
        transform.GetChild(0).GetComponent<Image>().enabled = false;
        transform.GetChild(1).GetComponent<Image>().enabled = false;
        transform.GetChild(2).GetComponent<Image>().enabled = false;

        if (PlayerLifeController.GetLives() > 0)
            transform.GetChild(PlayerLifeController.GetLives() - 1).GetComponent<Image>().enabled = true;
	}
}
