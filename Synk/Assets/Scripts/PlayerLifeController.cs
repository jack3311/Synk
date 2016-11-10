using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerLifeController : MonoBehaviour
{
    private static int iPlayerMaxLives = 3;

    private static int iPlayerCurrentLives = 3;

    private static Rigidbody2D myRigidbody;
    private static ShieldController myShieldController;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myShieldController = GetComponent<ShieldController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLifeController.IsDead())
        {
            // restart level
            StartCoroutine(LoadLevelAfterDelay(2f));
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        iPlayerCurrentLives = iPlayerMaxLives;
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static bool RemoveLife()
    {
        if (myShieldController.IsShieldActive())
        {
        }
        else
        {
            iPlayerCurrentLives = iPlayerCurrentLives - 1;

        }


        // If player dies
        if (iPlayerCurrentLives <= 0)
        {
            // goto last touched checkpoint
            //myRigidbody.position = CheckpointController.GetLastActiveCheckpointPosition();
            //iPlayerCurrentLives = iPlayerMaxLives;
            return true;
        }
        return false;
    }

    public static bool IsDead()
    {
        if (iPlayerCurrentLives <= 0)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
