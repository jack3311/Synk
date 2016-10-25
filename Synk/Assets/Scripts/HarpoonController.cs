using UnityEngine;
using System.Collections;

public class HarpoonController : MonoBehaviour {

    [SerializeField]
    private GameObject harpoonBulletPrefab;

    [SerializeField]
    private float harpoonForce;

    [SerializeField]
    private float offset;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject harpoonBullet = Instantiate(harpoonBulletPrefab);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 fDirection = mousePos - (rigidBody.position + (0.5f * boxCollider.size));
            fDirection.Normalize();

            harpoonBullet.transform.position = new Vector2(transform.position.x, transform.position.y) + fDirection * boxCollider.size.magnitude;

            HarpoonBulletController harpoonScript = harpoonBullet.GetComponent<HarpoonBulletController>();

            harpoonScript.playerRigidBody = rigidBody;
            harpoonScript.playerTransform = transform;
            
            harpoonBullet.GetComponent<Rigidbody2D>().AddForce(fDirection * harpoonForce);
        }
    }
}
