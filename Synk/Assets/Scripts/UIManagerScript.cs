using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

    [SerializeField]
    private GameObject UICanvas;

    [SerializeField]
    private GameObject MainPauseMenu;
    [SerializeField]
    private GameObject OptionsPauseMenu;

    [SerializeField]
    private GameObject GlitchImage;

    bool PauseMenuShown = false;

	// Use this for initialization
    void Start () {
        UICanvas.GetComponent<Animator>().enabled = false;

        MainPauseMenu.SetActive(true);
        Button[] mainPauseMenuButtons = MainPauseMenu.GetComponentsInChildren<Button>();
        foreach (Button b in mainPauseMenuButtons)
        {
            b.interactable = true;
        }

        OptionsPauseMenu.SetActive(false);
        Button[] optionsPauseMenuButtons = OptionsPauseMenu.GetComponentsInChildren<Button>();
        foreach (Button b in optionsPauseMenuButtons)
        {
            b.interactable = false;
        }
    }
	
	//// Update is called once per frame
	//void Update () {
	
	//}

    public void ResetGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    void Glitch()
    {
        //GlitchImage.SetActive(true);
        //GlitchImage.GetComponent<Animator>().Play("MenuGlitch");
    }

    public void OptionsButton()
    {
        Glitch();

        MainPauseMenu.SetActive(false);
        Button[] mainPauseMenuButtons = MainPauseMenu.GetComponentsInChildren<Button>();
        foreach (Button b in mainPauseMenuButtons)
        {
            b.interactable = false;
        }

        OptionsPauseMenu.SetActive(true);
        Button[] optionsPauseMenuButtons = OptionsPauseMenu.GetComponentsInChildren<Button>();
        foreach (Button b in optionsPauseMenuButtons)
        {
            b.interactable = true;
        }
    }

    public void OptionsBackButton()
    {
        Glitch();

        MainPauseMenu.SetActive(true);
        Button[] mainPauseMenuButtons = MainPauseMenu.GetComponentsInChildren<Button>();
        foreach (Button b in mainPauseMenuButtons)
        {
            b.interactable = true;
        }

        OptionsPauseMenu.SetActive(false);
        Button[] optionsPauseMenuButtons = OptionsPauseMenu.GetComponentsInChildren<Button>();
        foreach (Button b in optionsPauseMenuButtons)
        {
            b.interactable = false;
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuShowHideButton()
    {
        //OptionsBackButton();

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
