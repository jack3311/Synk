using UnityEngine;
using System.Collections;

public class FollowShipScript : MonoBehaviour {

    [SerializeField]
    private Transform shipTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = shipTransform.position + new Vector3(0, 7, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody = other.GetComponent<Rigidbody2D>();
            while (!PlayerLifeController.RemoveLife()) {  }
        }
    }
}
