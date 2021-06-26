using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    private Rigidbody2D myBody;
    private BoxCollider2D myCollider;
    private AudioSource audioSource;
    private Animator anim;

    private Transform myTransform;

    // Start is called before the first frame update
    //Player warrior;
    //Player archer;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        myTransform = transform;
        myTransform.position = new Vector3(10, 20, 30); 
        
        //warrior = new Player(100,2,"Ash");
        //archer = new Player(100, 1, "Elspeth");

        //warrior.SetHealth(20);

        //Debug.Log("The health of the warrior is: " + warrior.GetHealth());

        //Warrior warrior = new Warrior();
        //warrior.Info();
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
