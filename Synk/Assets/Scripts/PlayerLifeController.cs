﻿using UnityEngine;
using System.Collections;

public class PlayerLifeController : MonoBehaviour
{
    private static int iPlayerMaxLives = 3;

    private static int iPlayerCurrentLives = 3;

    private static Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLifeController.IsDead())
        {
            // restart level
            Application.LoadLevel(Application.loadedLevelName);
            iPlayerCurrentLives = iPlayerMaxLives;
        }
    }

    public static bool RemoveLife()
    {

        iPlayerCurrentLives = iPlayerCurrentLives - 1;

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
