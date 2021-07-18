using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{
    public PlayerMovement MyPlayer;

    private float speedMultiplier = 1.6f;
    void Start()
    {
        MyPlayer.speed *= speedMultiplier;
    }

    void Update()
    {
    }
}
