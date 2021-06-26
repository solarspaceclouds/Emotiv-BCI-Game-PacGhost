using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        // or: if (other.gameObject.name == "Food") // for this specific instance of an object
        if (other.gameObject.CompareTag("Food")) // for all objects with this tag.
        {
            //Destroy(other.gameObject);
            //or
            GetComponent<Renderer>().enabled = false;
        }
    }
}