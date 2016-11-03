using UnityEngine;
using System.Collections;

public class HarpoonController : MonoBehaviour {

    [SerializeField]
    private GameObject harpoonBulletPrefab;

    [SerializeField]
    private GameObject harpoonChainPrefab;

    [SerializeField]
    private float harpoonForce;

    [SerializeField]
    private float offset;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    private float harpoonFireCounter = 2;

    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        harpoonFireCounter += Time.deltaTime;

        bool canFire = (GameObject.FindGameObjectsWithTag("HarpoonBullet").Length == 0);



        if (Input.GetMouseButtonDown(1) && harpoonFireCounter >= 2f && canFire)
        {
            harpoonFireCounter = 0;

            GameObject harpoonBullet = Instantiate(harpoonBulletPrefab);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 fDirection = mousePos - (rigidBody.position + (0.5f * boxCollider.size));
            fDirection.Normalize();

            harpoonBullet.transform.position = new Vector2(transform.position.x, transform.position.y) + fDirection * boxCollider.size.magnitude;

            HarpoonBulletController harpoonScript = harpoonBullet.GetComponent<HarpoonBulletController>();

            harpoonScript.playerRigidBody = rigidBody;
            harpoonScript.playerTransform = transform;
            
            harpoonBullet.GetComponent<Rigidbody2D>().AddForce(fDirection * harpoonForce);


            //Setup line renderer
            GameObject harpoonChain = Instantiate(harpoonChainPrefab);
            lineRenderer = harpoonChain.GetComponent<LineRenderer>();

            canFire = false;

        }


        //Render line if harpoon bullet exists
        if (canFire)
        {
            Component.Destroy(lineRenderer);
            Object.Destroy(GameObject.FindGameObjectWithTag("HarpoonChain"));
            lineRenderer = null;
        }
        else
        {
            //Update line renderer
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, GameObject.FindGameObjectWithTag("HarpoonBullet").transform.position);
        }
    }
}
