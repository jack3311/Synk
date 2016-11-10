using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitlePressAnyKeyScript : MonoBehaviour {

    [SerializeField]
    private string targetScene;

    [SerializeField]
    private GameObject shipObject;

    private float startedTime;

	// Use this for initialization
	void Start () {
        startedTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.anyKeyDown && Time.fixedTime > startedTime + 1f)
        {

            if (shipObject != null)
            {
                shipObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            StartCoroutine(LoadLevelAfterDelay(2f));
        }
	}

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TimeTrackerScript.ResetTimer();
        SceneManager.LoadScene(targetScene);
    }
}
