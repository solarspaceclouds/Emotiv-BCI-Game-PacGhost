using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowDown : MonoBehaviour
{
    public Chase MyEnemy1;
    public Chase MyEnemy2;
    public Chase MyEnemy3;
    public Chase MyEnemy4;

    private float speedMultiplier = 0.4f;
    void Start()
    {
        MyEnemy1.speed *= speedMultiplier;
        MyEnemy2.speed *= speedMultiplier;
        MyEnemy3.speed *= speedMultiplier;
        MyEnemy4.speed *= speedMultiplier;
    }
    //public Chase MyEnemy1;
    //public Chase MyEnemy2;
    //public Chase MyEnemy3;
    //public Chase MyEnemy4;

    //private float speedMultiplier = 0.4f;
    //void Start()
    //{
    //    MyEnemy1.speed *= speedMultiplier;
    //    MyEnemy2.speed *= speedMultiplier;
    //    MyEnemy3.speed *= speedMultiplier;
    //    MyEnemy4.speed *= speedMultiplier;
    //}
}
