using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    public GameObject speedController;
    enum MC_Action
    {
        neutral = 0,
        push,
        pull,
        left,
        right
    }


    public static int action = (int)MC_Action.neutral;
    float last_action = (int)MC_Action.neutral;


    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (last_action != action)
        {
            last_action = action;
            transform.localPosition = new Vector3(0, 0, 0);
        }

        switch (action)
        {
            case (int)MC_Action.neutral:
                Debug.Log("neutral");
                speedController.SetActive(true);
                break;
            case (int)MC_Action.push:
                Debug.Log("pushing");
                speedController.SetActive(false);
                break;
            //case (int)MC_Action.pull:
            //    Debug.Log("pulling");
            //    break;
            //case (int)MC_Action.left:
            //    Debug.Log("left...");
            //    break;
            //case (int)MC_Action.right:
            //    Debug.Log("right...");
            //    break;
            default:
                Debug.Log("Not supported!");
                break;
        }

        if (action == 0)
        {

        }
        else
        {

        }
    }
}