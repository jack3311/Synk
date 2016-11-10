using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {

    [SerializeField]
    private float shieldDurationSecs;

    [SerializeField]
    private GameObject playerShieldImage;

    private float disableTime = 0f;

	// Use this for initialization
	void Start () {
    }

    public void ActivateShield()
    {
        disableTime = Mathf.Max(Time.fixedTime + shieldDurationSecs, disableTime + shieldDurationSecs);
    }

    public bool IsShieldActive()
    {
        return Time.fixedTime <= disableTime;
    }
	
	// Update is called once per frame
	void Update () {
        playerShieldImage.GetComponent<SpriteRenderer>().enabled = IsShieldActive();
    }
}
