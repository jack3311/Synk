using UnityEngine;
using System.Collections;

public class MineController : MonoBehaviour {
    // Final additions
    // Chain to game object
    // Invuln after being hit
    // Not necessary additions but include in polishing
    private LineRenderer lineRenderer;

    [SerializeField]
    private float explosionForce;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
            //Component.Destroy(lineRenderer);
            //Object.Destroy(GameObject.FindGameObjectWithTag("HarpoonChain"));
            //lineRenderer = null;
            //lineRenderer.SetVertexCount(2);
            //lineRenderer.SetPosition(0, transform.position);
            //lineRenderer.SetPosition(1, GameObject.FindGameObjectWithTag("HarpoonBullet").transform.position);

	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("Player"))
        {
            // make the player lose a life
            // send him in A direction

            if (!coll.GetComponent<ShieldController>().IsShieldActive())
            {
                Rigidbody2D playerRigidBody = coll.GetComponent<Rigidbody2D>();
                // lose a life
                playerRigidBody.AddForce(new Vector2(0, explosionForce));

            }
            Destroy(this.gameObject);
        }
        else if (coll.CompareTag("HarpoonBullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
