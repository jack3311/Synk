using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {

    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;

    private Vector2 cpPos1, cpPos2;

    [SerializeField]
    private float speed;

    private float time = 0;

    [SerializeField]
    private float pushVelocity = 2f;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        cpPos1 = pos1.position;
        cpPos2 = pos2.position;

        rigidBody = GetComponent<Rigidbody2D>();
        transform.position = cpPos1;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        //Vector2 delta = cpPos2 - cpPos1;

        Vector2 middle = 0.5f * (cpPos2 - cpPos1) + cpPos1;
        Vector2 delta = new Vector2(transform.position.x, transform.position.y) - middle;

        //float dist = (Mathf.Sin(time * speed) / 2.0f) + 0.5f;

        //float vel = (Mathf.Cos(time * speed) * speed * 0.5f);

        Vector2 accel = -Mathf.Pow(2 * Mathf.PI * speed, 2) * delta.magnitude * delta.normalized;

        //rigidBody.AddForce(delta * force);

        rigidBody.velocity += accel * Time.deltaTime;

        //transform.position = cpPos1 + delta * dist;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        /*Rigidbody2D other = coll.gameObject.GetComponent<Rigidbody2D>();

        Vector2 CollDir = other.position - new Vector2(transform.position.x, transform.position.y);
        CollDir.Normalize();

        float delta = 0.5f * speed * Mathf.Cos(time * speed);
        
        Vector2 vel = cpPos2 - cpPos1;
        //vel.Normalize();
        vel *= delta;


        float aDotB = Vector2.Dot(vel, CollDir);
        Vector2 aDotBTimesB = (CollDir) * aDotB;

        Vector2 proj = aDotBTimesB / Mathf.Pow(CollDir.magnitude, 2f);

        //Debug.Log(proj);

        other.AddForce(pushVelocity * proj);
        //other.AddForce(aDotB * proj);*/
    }
}
