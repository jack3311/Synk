using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;

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

        if (bubbleGunActive)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 fDirection = mousePos - (myRigidbody.position + (0.5f * myBoxCollider.size));
            fDirection.Normalize();
            fDirection *= -bubbleGunForce;

            //myRigidbody.velocity = myRigidbody.velocity + fDirection * dt;

            myRigidbody.AddForce(fDirection, ForceMode2D.Force);

            //myRigidbody.velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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


        if (swimmingLeft) myRigidbody.AddForce(new Vector2(-swimForce, 0));
        if (swimmingUp) myRigidbody.AddForce(new Vector2(0, swimForce));
        if (swimmingRight) myRigidbody.AddForce(new Vector2(swimForce, 0));
        if (swimmingDown) myRigidbody.AddForce(new Vector2(0, -swimForce));

    }
}
