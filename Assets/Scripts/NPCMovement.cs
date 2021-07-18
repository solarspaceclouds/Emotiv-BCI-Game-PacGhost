using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    // to add a bit of random movements.. 
    public float moveForce = 2f;
    
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX, movementY;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;

    //private string GROUND_TAG = "Ground";
    // Start is called before the first frame update

    [SerializeField]
    private float minX, maxX, minY, maxY;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMoveKeyboard();
        AnimatePlayer();

     }

    private void FixedUpdate()
    {
       
        //PlayerJump();
        AnimatePlayer();
    }

    //void PlayerMoveKeyboard()
    //{
    //    movementX = Input.GetAxisRaw("Horizontal");
    //    transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    //    movementY = Input.GetAxisRaw("Vertical");
    //    transform.position += new Vector3(0f, movementY, 0f) * moveForce * Time.deltaTime;
    //}

    void AnimatePlayer()
    {
        //while(true)
        //{
        //    anim.SetBool(WALK_ANIMATION, true);
        //}
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    //void PlayerJump()
    //{
    //    if (Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        isGrounded = false;
    //        myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag(GROUND_TAG))
    //    {
    //        isGrounded = true;
    //    }

    //}


}
