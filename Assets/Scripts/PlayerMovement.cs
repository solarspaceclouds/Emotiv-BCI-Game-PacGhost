using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static bool gameOver = false;

    public float speed = 4f;
    // Start is called before the first frame update
    //private string WALL_TAG = "Wall";
    //private string ENEMY_TAG = "Enemy";
    //private string FOOD_TAG = "Food";


    [SerializeField]
    private float minX, maxX, minY, maxY;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}