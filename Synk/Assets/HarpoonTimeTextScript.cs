using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HarpoonTimeTextScript : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject harpoonImage;

    private HarpoonController hc;

    // Use this for initialization
    void Start ()
    {
        hc = player.GetComponent<HarpoonController>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = hc.IsHarpoonActive() ? Mathf.FloorToInt(hc.TimeRemaining()).ToString() : "";
        harpoonImage.SetActive(hc.IsHarpoonActive());
	}
}
