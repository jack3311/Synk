using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private GameObject[] explosionObjects;

    [SerializeField]
    private float knockbackForce;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(0, -speed);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody = other.GetComponent<Rigidbody2D>();
            if (PlayerLifeController.RemoveLife())
            {
                // Might change this with death animation (in remove life function)
                foreach (GameObject go in explosionObjects)
                    Instantiate(go, other.transform.position, Quaternion.identity);
            }
            playerRigidBody.AddForce(new Vector2(0, -knockbackForce));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.collider.CompareTag("WALL") && !coll.collider.CompareTag("Player"))
        {
            foreach (GameObject go in explosionObjects)
                Instantiate(go, coll.collider.transform.position, Quaternion.identity);

            if (GetComponent<Renderer>().isVisible)
            {
                Camera.main.GetComponent<CameraShake>().ShakeFor(1f);
            }

            Destroy(coll.gameObject, 0.01f);
        }
        
    }
}
