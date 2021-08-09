using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject target;
    //public float slowMultiplier = 1.0f;
    public float speed;
    public float boostTimer;
    public bool boosting;

    // to add a bit of random movements.. 

    private void Update()
    {
        Debug.Log("EnemySpeedPM: " + speed);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * slowMultiplier * Time.deltaTime);
        if (boosting)
        {
            speed = 0.0001f;
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                speed = 1f;
                boostTimer = 0f;
                boosting = false;
            }
        }
    }

    //public IEnumerator StopSlowDown()
    //{
    //    yield return new WaitForSeconds(6f); // the number corresponds to the number of seconds the speed up will be applied
        
    //    slowMultiplier = 1.0f; // back to normal !
    //}
}
