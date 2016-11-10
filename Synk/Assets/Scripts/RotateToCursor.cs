using UnityEngine;
using System.Collections;

public class RotateToCursor : MonoBehaviour {
    public Vector3 mousePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //difference between 2 points;
        Vector3 diff = mousePos - transform.position;

        //find the angle of this diff
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        if (mousePos.x < transform.position.x)
        {
            angle += 180f;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180f));
        
	}
}
