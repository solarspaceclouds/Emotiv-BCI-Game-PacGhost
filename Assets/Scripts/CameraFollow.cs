using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX, minY, maxY;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        if (tempPos.y < minY)
        {
            tempPos.y = minY;
        }

        if (tempPos.y > maxY)
        {
            tempPos.y = maxY;
        }


        transform.position = tempPos;
    }
}
