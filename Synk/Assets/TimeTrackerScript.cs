using UnityEngine;
using System.Collections;

public class TimeTrackerScript : MonoBehaviour {

    private static float timerCurrent = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timerCurrent += Time.deltaTime;
	}

    public static void ResetTimer()
    {
        timerCurrent = 0f;
    }

    public static float GetTime()
    {
        return timerCurrent;
    }
}
