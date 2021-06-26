using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public bool canMove = true;

    public static bool gameOver = false;
    public GameObject gameOverPanel;

    private bool didStartDeath = false;

    public float speed = 5f;
    // Start is called before the first frame update
    //private string WALL_TAG = "Wall";
    private string ENEMY_TAG = "Enemy";
    private string FOOD_TAG = "Food";


    [SerializeField]
    private float minX, maxX, minY, maxY;
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        if (pos.x < minX)
        {
            pos.x = minX;
        }

        if (pos.x > maxX)
        {
            pos.x = maxX;
        }

        if (pos.y < minY)
        {
            pos.y = minY;
        }

        if (pos.y > maxY)
        {
            pos.y = maxY;
        }

        transform.position = pos;
    }

    //public void StartDeath()
    //{
    //    if (!didStartDeath)
    //    {
    //        didStartDeath = true;

    //        GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost");

    //        foreach (GameObject ghost in o)
    //        {
    //            ghost.transform.GetComponent<NPCMovement>()
    //        }
    //    }
    //
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("Hi");
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Hi2");
    //        GameObject[] o = GameObject.FindGameObjectsWithTag("Enemy");
    //        foreach(GameObject ghost in o)
    //        {
    //            ghost.transform.GetComponent<SpriteRenderer>().enabled = false;
    //        }
    //        Destroy(gameObject);
    //        SceneManager.LoadScene("Game Over");
    //        //gameOverPanel.SetActive(true);
            
    //        //collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    //        //Destroy(collision.gameObject);
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        gameOverPanel.SetActive(true);
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnCollisionEnter2D(ControllerColliderHit col)
    //{
    //    if (col.gameObject.CompareTag("Enemy"))
    //    {
    //        PlayerAliveStatus.gameOver = true;
    //    }
    //}

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if(hit.transform.tag == "Enemy")
    //    {
    //        PlayerAliveStatus.gameOver = true;
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        //ANIMATION_PLAYER_DIED
    //        Destroy(gameObject); //destroy player
    //    }
    //}
}