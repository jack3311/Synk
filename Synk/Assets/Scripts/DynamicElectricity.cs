using UnityEngine;
using System.Collections;

public class DynamicElectricity : MonoBehaviour {

    [SerializeField]
    private float explosionForce;

    [SerializeField]
    private float switchSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = IsOn();
    }

    bool IsOn()
    {
        int currentTime = Mathf.FloorToInt(Time.fixedTime / switchSpeed);
        return (currentTime % 2 == 0);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!IsOn()) return;

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
