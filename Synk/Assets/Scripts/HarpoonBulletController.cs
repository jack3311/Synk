using UnityEngine;
using System.Collections;

public class HarpoonBulletController : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public Transform playerTransform;

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidBody;
    private Renderer renderer;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 delta = transform.position - playerTransform.position;
        delta.Normalize();

        Vector2 force = delta * speed;

        playerRigidBody.AddForce(force);

        Camera.main.GetComponent<CameraShake>().ShakeFor(0.3f);

        Destroy(this.gameObject);
    }
}
