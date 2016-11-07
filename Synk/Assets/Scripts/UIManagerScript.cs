using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

    [SerializeField]
    private GameObject UICanvas;

    bool PauseMenuShown = false;

	// Use this for initialization
    void Start () {
        UICanvas.GetComponent<Animator>().enabled = false;
    }
	
	//// Update is called once per frame
	//void Update () {
	
	//}

    public void ResetGameButton()
    {
        Application.LoadLevel("Test Scene");
        Time.timeScale = 1;
    }

    public void OptionsButton()
    {
        Application.LoadLevel("Test Scene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuShowHideButton()
    {
        if (PauseMenuShown)
        {
            UICanvas.GetComponent<Animator>().enabled = true;
            UICanvas.GetComponent<Animator>().Play("MenuSlideOut");
            Time.timeScale = 1;
        }
        else
        {
            UICanvas.GetComponent<Animator>().enabled = true;
            UICanvas.GetComponent<Animator>().Play("MenuSlideIn");
            Time.timeScale = 0;
        }

        PauseMenuShown = !PauseMenuShown;
    }
}
