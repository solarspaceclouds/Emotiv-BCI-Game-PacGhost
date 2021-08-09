using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject BrainFramework;
    private BrainFramework EPOC;

    private Rigidbody Ball;

    public int neutralCount1 = 0;
    public int clenchCount1 = 0;
    public int furrowCount1 = 0;
    public int smileCount1 = 0;
    public int stressCount1 = 0;
    public int exciteCount1 = 0;
    public int relaxCount1 = 0;
    public int longExciteCount1 = 0;

    void Start()
    {
        Debug.Log("BallControllerScript is Running! :D");
        Debug.Log("");
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
        Debug.Log("Ball EPOC Ready!");


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
        Debug.Log("BallStream");
        Debug.Log($"command: { EPOC.BRAIN.command } | eyeAction: { EPOC.BRAIN.eyeAction } | upperFaceAction: { EPOC.BRAIN.upperFaceAction } | lowerFaceAction: { EPOC.BRAIN.lowerFaceAction } ");//| metrics: {EPOC.BRAIN.metric}
    }
    //void Try()
    //{
    //    Debug.Log("Metric Length: " + EPOC.BRAIN.metric.Length);
    //    for (int i = 0; i < EPOC.BRAIN.metric.Length; i++)
    //    {
    //        Debug.Log("EPOC Metric " + i + ": " + EPOC.BRAIN.metric[i]);
    //    }
    //}


    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("BallFixedUpdate");
        // BALL MOVEMENT EXAMPLE
        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

        //if (EPOC.BRAIN.command == "neutral")
        if (EPOC.BRAIN.lowerFaceAction == "smile") //push
        {
            movement = new Vector3(0.0f, 0.0f, 1.0f);
            smileCount1++;
            Debug.Log("smile");
        }
        if (EPOC.BRAIN.command == "pull")
        {
            movement = new Vector3(0.0f, 0.0f, -1.0f);
        }
        if (EPOC.BRAIN.command == "left")
        {
            movement = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (EPOC.BRAIN.command == "right")
        {
            movement = new Vector3(1.0f, 0.0f, 0.0f);
        }

        //Debug.Log("EPOCBRAINMETRIC: " + EPOC.BRAIN.metric);

        //
        if (EPOC.BRAIN.command == "neutral")
        {
            Debug.Log("Neutral!");
            //activate player speed up script gameobject
            neutralCount1++;
        }
        if (EPOC.BRAIN.lowerFaceAction == "clench")
        {
            Debug.Log("Clench");
            clenchCount1++;
        }

        //if (EPOC.BRAIN.metric == "exc")
        //{
        //    Debug.Log("Excited!");
        //    exciteCount1++;
        //}
        //if (EPOC.BRAIN.metric == "lex")
        //{
        //    Debug.Log("LongEx!");
        //    longExciteCount1++;
        //}
        //if (EPOC.BRAIN.metric == "str")
        //{
        //    Debug.Log("Stressed!");
        //    stressCount1++;
        //}
        //if (EPOC.BRAIN.metric == "rel")
        //{
        //    Debug.Log("Relaxed!");
        //    relaxCount1++;
        //}


        Ball.AddForce(movement);
    }
}
