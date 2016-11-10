using UnityEngine;
using System.Collections;

public class StaticElectricityController : MonoBehaviour {

    [SerializeField]
    private float explosionForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody = coll.GetComponent<Rigidbody2D>();
            // lose a life

            if (!PlayerLifeController.RemoveLife())
            {
                playerRigidBody.AddForce(new Vector2(0, explosionForce));
            }
        }
    }
    
}
