using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntangibleGhosts : MonoBehaviour
{
    // Start is called before the first frame update
    public float sec = 5f;
    void Start()
    {
        //if (gameObject.activeInHierarchy)
        //{
        //    gameObject.SetActive(false);
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(this.gameObject); //to get rid of the object fully (not just become invisible)
    //        // or: GetComponent<Renderer>().enabled = false; // if you don't mind the object still blocking there, as long as it is invisible
    //    }
    //    //    if (other.gameObject.tag == "Player")
    //    //    {
    //    //        Destroy(gameObject);
    //    ////or gameObject.SetActive(false);
    //    //    }

    //}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("HideShowGameObject", 4);
            //StartCoroutine(ActivationRoutine());
        }
        //Wait for 2 seconds  
    }
    //void HideShowGameobject()
    //{
    //    if (objectToHide.active)
    //        objectToHide.SetActive(false);
    //    else
    //        objectToHide.SetActive(true);
    //}

    //IEnumerator ActivationRoutine()
    //{
    //    //
    //    yield return new WaitForSeconds(sec);
    //    GetComponent<BoxCollider2D>().enabled = true;
    //    //gameObject.SetActive(true);

    //    //        
    //    //{
    //    //    //    Start.timer += Time.deltaTime;
    //    //    //    {
    //    //    //        GetComponent<BoxCollider2D>().enabled = false;
    //    //    //    }
    //    //    //}
    //    //    //else
    //    //    //{
    //    //    //    GetComponent<BoxCollider2D>().enabled = true;
    //    //    //}
    //    //}
    //}
}
