using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySlowDown : MonoBehaviour
{
    public GameObject[] RealEnemyCollection;

    private float speedMultiplier = 0.4f;
    void Start()
    {
        foreach (GameObject enemy in RealEnemyCollection)
        {
            enemy.GetComponent<Chase>().speed *= speedMultiplier;
        }
    }
}
