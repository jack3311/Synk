using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(0, -speed);
	}
}
