using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour {

    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;

    private Vector2 cpPos1, cpPos2;
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float explosionForce;

    // Use this for initialization
    void Start () {
        cpPos1 = pos1.position;
        cpPos2 = pos2.position;

        rigidBody = GetComponent<Rigidbody2D>();
        transform.position = cpPos1;
    }

	// Update is called once per frame
	void Update () {
        Vector2 middle = 0.5f * (cpPos2 - cpPos1) + cpPos1;
        Vector2 delta = new Vector2(transform.position.x, transform.position.y) - middle;

        //float dist = (Mathf.Sin(time * speed) / 2.0f) + 0.5f;

        //float vel = (Mathf.Cos(time * speed) * speed * 0.5f);

        Vector2 accel = -Mathf.Pow(2 * Mathf.PI * speed, 2) * delta.magnitude * delta.normalized;
        
        if (rigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //rigidBody.AddForce(delta * force);

        rigidBody.velocity += accel * Time.deltaTime;
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
