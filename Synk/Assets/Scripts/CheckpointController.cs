using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
    private static GameObject[] Checkpoints;

    protected bool Activated = false;


	void Start () {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision with checkpoint");

        if (other.tag == "Player")
        {
            //Activate this checkpoint, deactivate others

            foreach (GameObject go in Checkpoints)
            {
                go.GetComponent<CheckpointController>().Activated = false;
            }

            Activated = true;
        }
    }

    public static Vector2 GetLastActiveCheckpointPosition()
    {
        if (Checkpoints != null)
        {
            foreach (GameObject go in Checkpoints)
            {
                if (go.GetComponent<CheckpointController>().Activated)
                {
                    return new Vector2(go.transform.position.x, go.transform.position.y)
                        + (go.GetComponent<BoxCollider2D>().size / 2);
                }
            }
        }

        return new Vector2(0, 0);
    }
}
