using UnityEngine;
using System.Collections;

public class BootsController : MonoBehaviour {

    Rigidbody2D playerRigidBody2D;

    [SerializeField]
    private float bootsDurationSecs;

    private float disableTime = 0f;

    // Use this for initialization
    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void ActivateBoots()
    {
        disableTime = Mathf.Max(Time.fixedTime + bootsDurationSecs, disableTime + bootsDurationSecs);
    }

    public bool IsBootsActive()
    {
        return Time.fixedTime <= disableTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBootsActive())
        {
            playerRigidBody2D.gravityScale = 0.5f;
        }
        else
        {
            playerRigidBody2D.gravityScale = 0.05f;
        }
    }
}
