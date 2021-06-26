using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteSomething());

        StartCoroutine("ExecuteSomething");
        StopCoroutine("ExecuteSomething");
    }

    // Update is called once per frame
    IEnumerator ExecuteSomething()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Something is executed");

        yield return new WaitForSeconds(2f);
        // none
        yield return new WaitForSeconds(2f);
    }
}
