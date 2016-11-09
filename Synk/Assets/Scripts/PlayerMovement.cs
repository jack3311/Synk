using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;

    private ParticleSystem bubbleGunParticles;

    [SerializeField]
    private GameObject bubbleGunParticlesObject;

    [SerializeField]
    private GameObject harpoonGunSprite;

    public float bubbleGunForce;
    public float swimForce;

    private bool bubbleGunActive = false;

    private bool swimmingLeft = false;
    private bool swimmingRight = false;
    private bool swimmingUp = false;
    private bool swimmingDown = false;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        bubbleGunParticles = bubbleGunParticlesObject.GetComponent<ParticleSystem>();
        harpoonGunSprite = GameObject.Find("PlayerHarpoon");
    }
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            bubbleGunActive = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            bubbleGunActive = false;
        }

        bubbleGunParticlesObject.transform.position = transform.position;
        bubbleGunParticles.enableEmission = bubbleGunActive;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (bubbleGunActive)
        {
            Vector2 fDirection = mousePos - (myRigidbody.position);
            fDirection.Normalize();
            fDirection *= -bubbleGunForce;

            //myRigidbody.velocity = myRigidbody.velocity + fDirection * dt;

            myRigidbody.AddForce(fDirection, ForceMode2D.Force);

            bubbleGunParticlesObject.transform.LookAt(mousePos);

            //myRigidbody.velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (mousePos.x > transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            /*HingeJoint2D harpoonHinge = harpoonGunSprite.GetComponent<HingeJoint2D>();
            harpoonGunSprite.transform.RotateAround(new Vector3(harpoonHinge.anchor.x + transform.position.x,
                harpoonHinge.anchor.y + transform.position.y, 0), new Vector3(0, 0, 1), 30);*/
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.A)) swimmingLeft = true;
        if (Input.GetKeyDown(KeyCode.W)) swimmingUp = true;
        if (Input.GetKeyDown(KeyCode.S)) swimmingDown = true;
        if (Input.GetKeyDown(KeyCode.D)) swimmingRight = true;

        if (Input.GetKeyUp(KeyCode.A)) swimmingLeft = false;
        if (Input.GetKeyUp(KeyCode.W)) swimmingUp = false;
        if (Input.GetKeyUp(KeyCode.S)) swimmingDown = false;
        if (Input.GetKeyUp(KeyCode.D)) swimmingRight = false;

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = CheckpointController.GetLastActiveCheckpointPosition();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<HarpoonController>().ActivateHarpoon();
        }

        if (swimmingLeft) myRigidbody.AddForce(new Vector2(-swimForce, 0));
        if (swimmingUp) myRigidbody.AddForce(new Vector2(0, swimForce));
        if (swimmingRight) myRigidbody.AddForce(new Vector2(swimForce, 0));
        if (swimmingDown) myRigidbody.AddForce(new Vector2(0, -swimForce));


        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(myRigidbody.velocity.y, myRigidbody.velocity.x) * Mathf.Rad2Deg - 90, new Vector3(0, 0, 1)); //Quaternion.LookRotation(myRigidbody.velocity, new Vector3(0, 1, 0));
    }
}
