using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelWinController : MonoBehaviour {

    [SerializeField]
    private string TargetSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(TargetSceneName);
        }
    }
}
