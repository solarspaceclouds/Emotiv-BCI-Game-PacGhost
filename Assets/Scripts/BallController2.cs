﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour
{
    public GameObject BrainFramework;
    private BrainFramework EPOC;

    private Rigidbody Ball;

    public GameObject realEnemyCollection; 
    public PlayerMovement playerMovement;
    public Chase chase;

    public GameObject smileOnIndicator;
    public GameObject smileOffIndicator;
    public static int smileCount = 0;

    //public static int smileCount = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        chase = realEnemyCollection.GetComponent<Chase>();
    }
    void Start()
    {
        // ---------- BRAIN FRAMEWORK-----------
        // 1. Connect to EPOC Script
        EPOC = BrainFramework.GetComponent<BrainFramework>();

        // 2. Subscribe to Events
        EPOC.On("READY", Ready);
        EPOC.On("STREAM", Stream);
        // ------------------------------------

        // Prepare Ball
        Ball = GetComponent<Rigidbody>();


    }

    // EPOC IS READY
    void Ready()
    {
        //speedController.SetActive(false);
        Debug.Log("EPOC Ready!");


        // START STREAM
        EPOC.StartStream();


        // ------ TRAINING -------
        // It is best to place this command on a key, 
        // but make sure to call it after the "READY" event:

        // EPOC.StartTraining("neutral");

        // The next 8 seconds will then be recorded and saved into the profile

        // These are the parameters you could train:
        //"neutral"
        //"push"
        //"pull"
        //"lift"
        //"drop"
        //"left"
        //"right"
        //"rotateLeft"
        //"rotateRight"
        //"rotateClockwise"
        //"rotateCounterClockwise"
        //"rotateForwards"
        //"rotateReverse"
        //"disappear"

        // You could also listen to this events:
        // trainingStarted
        // trainingSucceeded
        // trainingCompleted

        // At the end of a training session you can save your progress to the profile
        // Call this after an "trainingCompleted" event or manually. 
        // EPOC.SaveProfile();

    }

    // DATA STREAM
    void Stream()
    {
        Debug.Log($"command: { EPOC.BRAIN.command } | eyeAction: { EPOC.BRAIN.eyeAction } | upperFaceAction: { EPOC.BRAIN.upperFaceAction } | lowerFaceAction: { EPOC.BRAIN.lowerFaceAction } ");// | metrics: {EPOC.BRAIN.metric}| lowerFaceActionPow: {EPOC.BRAIN.lowerFaceActionPow}
    }


    // Update is called once per frame
    void Update()
    {
        //GameObject varGameObject = GameObject.Find("object"); 
        //GameObject varGameObject = GameObject.FindWithTag("Player");
        //varGameObject.GetComponent<scriptname>().enabled = true;

        //GameObject thePlayer = GameObject.Find("Circle");
        //SpeedUp playerScript = thePlayer.GetComponent<SpeedUp>();

        if (EPOC.BRAIN.lowerFaceAction == "smile")
        //if (EPOC.BRAIN.command == "neutral")
        {
            Debug.Log("Smile is On (Speed changes start)");
            playerMovement.boosting = true;
            chase.boosting = true;
            //smileCount++;
            //smileOnIndicator.SetActive(true);
            //smileOffIndicator.SetActive(false);
        }

        //// BALL MOVEMENT EXAMPLE
        //Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

        //if (EPOC.BRAIN.command == "push")
        //{
        //    movement = new Vector3(0.0f, 0.0f, 1.0f);
        //}
        //if (EPOC.BRAIN.command == "pull")
        //{
        //    movement = new Vector3(0.0f, 0.0f, -1.0f);
        //}
        //if (EPOC.BRAIN.command == "left")
        //{
        //    movement = new Vector3(-1.0f, 0.0f, 0.0f);
        //}
        //if (EPOC.BRAIN.command == "right")
        //{
        //    movement = new Vector3(1.0f, 0.0f, 0.0f);
        //}


        //Ball.AddForce(movement);
    }
}
